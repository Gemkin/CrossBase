using System;
using System.Collections.Generic;
using System.Threading;
using CrossBase.Log;
using CrossBase.Threading;

namespace CrossBase.Dispatch
{
    public class MainLoopDispatcher : IDispatcher
    {
        private readonly IDispatcher dispatcherToHandleExceptions;
        private static readonly ILogger log = SystemServices.LogManager.GetLogger("CrossBase.Dispatch.MainLoopDispatcher");
        private readonly Queue<Action> actions = new Queue<Action>();
        private readonly Object locker = new Object();
        private readonly Thread thread;
        private int lastCount; //debug logging
        private bool running;


        public MainLoopDispatcher(DispatcherId id)
            : this(id, false)
        {
        }

        public MainLoopDispatcher(DispatcherId id, bool usingOwnThread)
            : this(id, usingOwnThread, null)
        {
        }
        public MainLoopDispatcher(DispatcherId id, bool usingOwnThread, IDispatcher dispatcherToHandleExceptions)
        {
            this.dispatcherToHandleExceptions = dispatcherToHandleExceptions;
            Id = id;

            running = true;
            if (usingOwnThread)
            {
                thread = SystemServices.ThreadManager.GetCurrentThread();
                return;
            }


            thread = SystemServices.ThreadManager.Create(Run);
            SystemServices.ThreadManager.Start(thread);
        }

        #region IDispatcher Members

        public int ThreadId
        {
            get { return SystemServices.ThreadManager.GetThreadId(thread); }
        }

        public DispatcherId Id { get; private set; }

        public void BeginInvoke(Action actionToInvoke)
        {
            Monitor.Enter(locker);
            actions.Enqueue(actionToInvoke);
            var actionCount = actions.Count;
            Monitor.Pulse(locker);
            Monitor.Exit(locker);

            if (actionCount%10 == 0 && actionCount != lastCount)
            {
                lastCount = actionCount;
                log.InfoFormat("{0} actions in worker thread", actionCount);
            }
        }


        public void Invoke(Action actionToInvoke)
        {
            var mre = new ManualResetEvent(false);

            BeginInvoke(() =>
            {
                try
                {
                    actionToInvoke();

                }
                finally
                {
                    mre.Set();
                }
            });

            mre.WaitOne();
        }

        public void Dispose()
        {
            Monitor.Enter(locker);
            running = false;
            Monitor.Pulse(locker);
            Monitor.Exit(locker);

            log.Debug("Waiting for Mainloop to end");
            SystemServices.ThreadManager.Join(thread);
            log.Debug("Mainloop disposed");
        }

        #endregion

        public void Run()
        {
            log.Debug("Starting main loop");

            while (running)
            {
                try
                {
                    Action action;
                    Monitor.Enter(locker);
                    {
                        while (actions.Count == 0)
                        {
                            Monitor.Wait(locker);
                            if (!running)
                            {
                                Monitor.Exit(locker);
                                log.Debug("Mainloop exit (from critical section)");
                                return;
                            }
                        }
                        action = actions.Dequeue();
                    }
                    Monitor.Exit(locker);

                    if (action != null)
                        action.Invoke();
                }
                catch (Exception e)
                {
                    if (dispatcherToHandleExceptions != null)
                    {
                        log.Error(string.Format("Exception occured in {0} dispatcher, throwing in {1} dispatcher", Id, dispatcherToHandleExceptions.Id) + e.Message);
                        dispatcherToHandleExceptions.BeginInvoke(() =>
                        {
                            throw new Exception(string.Format("Exception occured in {0} dispatcher", Id), e);
                        });
                    }
                    else
                    {
                        log.Error(string.Format("Exception occured in {0} dispatcher, catched and but not retrown: ", Id) + e.Message);    
                    }
                }
            }
            log.Debug("Mainloop exit");
        }
    }
}
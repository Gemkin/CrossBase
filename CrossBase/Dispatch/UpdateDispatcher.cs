using System;
using System.Collections.Generic;
using System.Threading;
using CrossBase.Log;

namespace CrossBase.Dispatch
{
    public class UpdateDispatcher : IDispatcher
    {
        private readonly ILogger log;
        private readonly Queue<Action> actions = new Queue<Action>();
        private readonly Object locker = new Object();
        private int lastCount; //debug logging


        public UpdateDispatcher(DispatcherId id, ILogger log)
        {
            this.log = log;
            Id = id;
        }


        #region IDispatcher Members

        public int ThreadId
        {
            get { return SystemServices.ThreadManager.GetThreadId(Thread.CurrentThread); }
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
        }

        #endregion

        public void Update()
        {
            try
            {
                Action action = null;
                Monitor.Enter(locker);
                {
                    if (actions.Count != 0)
                    {
                        action = actions.Dequeue();
                    }
                }
                Monitor.Exit(locker);

                if (action != null)
                    action.Invoke();
            }
            catch (Exception e)
            {
                log.Error("UpdateDispatcher catched exception: " + e);
            }
        }
    }
}
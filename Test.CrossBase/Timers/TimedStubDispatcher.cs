using System;
using System.Threading;
using CrossBase;
using CrossBase.Dispatch;

namespace Test.CrossBase.Timers
{
    public class TimedStubDispatcher : IDispatcher
    {
        private readonly AutoResetEvent autoEvent = new AutoResetEvent(false);
        private Action method;

        public TimedStubDispatcher(Thread thread)
        {
            Thread = thread;
        }


        public Thread Thread { get; private set; }
        public int ThreadId { get { return SystemServices.ThreadManager.GetThreadId(Thread); } }

        public void BeginInvoke(Action methodToExecute)
        {
            method = methodToExecute;
            autoEvent.Set();
        }

        public void Invoke(Action methodToExecute)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public bool InvokeOccurrsWithinTimeout(int timeout)
        {
            autoEvent.Reset();
            if (autoEvent.WaitOne(timeout, false))
            {
                method();
                return true;
            }
            return false;
        }

        public DispatcherId Id
        {
            get { throw new NotImplementedException(); }
        }
    }
}
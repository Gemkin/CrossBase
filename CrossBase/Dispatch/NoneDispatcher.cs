using System;
using System.Threading;

namespace CrossBase.Dispatch
{
    public class NoneDispatcher : IDispatcher
    {
        public NoneDispatcher(DispatcherId id)
        {
            Id = id;
        }

        #region IDispatcher Members

        public int ThreadId
        {
            get { return Thread.CurrentThread.ManagedThreadId; }
        }

        public DispatcherId Id { get; private set; }

        public void BeginInvoke(Action methodToExecute)
        {
            methodToExecute();
        }

        public void Dispose()
        {
        }

        public void Invoke(Action methodToExecute)
        {
            methodToExecute();
        }

        #endregion
    }
}
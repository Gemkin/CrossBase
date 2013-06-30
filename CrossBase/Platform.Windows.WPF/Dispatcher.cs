using System;
using System.Windows.Threading;
using CrossBase.Dispatch;

namespace CrossBase.Platform.Windows.WPF
{
    public class Dispatcher : IDispatcher
    {
        private readonly System.Windows.Threading.Dispatcher dispatcher;

        public Dispatcher(System.Windows.Threading.Dispatcher dispatcher, DispatcherId id)
        {
            Id = id;
            this.dispatcher = dispatcher;
        }

        #region IDispatcher Members

        public int ThreadId
        {
            get { return dispatcher.Thread.ManagedThreadId; }
        }

        public void Invoke(Action methodToExecute)
        {
            dispatcher.Invoke(DispatcherPriority.Background, methodToExecute);
        }


        public void BeginInvoke(Action methodToExecute)
        {
            dispatcher.BeginInvoke(DispatcherPriority.Background, methodToExecute);
        }

        public void Dispose()
        {
        }

        public DispatcherId Id { get; private set; }

        #endregion
    }
}
using System;

namespace CrossBase.Dispatch
{
    public interface IDispatcher
    {
        int ThreadId { get; }
        DispatcherId Id { get; }
        void BeginInvoke(Action methodToExecute);
        void Invoke(Action methodToExecute);
        void Dispose();
    }
}
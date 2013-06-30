using System;

namespace CrossBase.Dispatch
{
    public interface IDispatcherManager:IDisposable
    {
        void Register(IDispatcher dispatcher);
        void Unregister(IDispatcher dispatcher);
        IDispatcher this[DispatcherId id] { get; }
    }
}
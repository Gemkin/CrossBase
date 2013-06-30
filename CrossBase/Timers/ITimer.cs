using System;
using CrossBase.Dispatch;

namespace CrossBase.Timers
{
    public interface ITimer
    {
        string Name { get; set; }
        int TimeOut { get; set; }
        IDispatcher Dispatcher { get; set; }
        event Action Tick;

        void Start();
        void Stop();
        void Dispose();
    }
}
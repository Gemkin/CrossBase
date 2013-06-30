using System;
using CrossBase.Dispatch;

namespace CrossBase.Timers
{
    public interface ITimerManager : IDisposable
    {
        ITimer CreateOneShot(string name, int timeOut, IDispatcher dispatcher);
        ITimer CreateMultiShotShot(string name, int timeOut, IDispatcher dispatcher);
    }
}
using CrossBase.Dispatch;

namespace CrossBase.Timers
{
    public class DefaultTimerManager : ITimerManager
    {
        public ITimer CreateOneShot(string name, int timeOut, IDispatcher dispatcher)
        {
            return new OneShotTimer(name, timeOut, dispatcher);
        }

        public ITimer CreateMultiShotShot(string name, int timeOut, IDispatcher dispatcher)
        {
            return new MultiShotTimer(name, timeOut, dispatcher);
        }

        public void Dispose()
        {
            
        }
    }
}
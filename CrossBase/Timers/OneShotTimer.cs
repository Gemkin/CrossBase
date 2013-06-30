using CrossBase.Dispatch;
using CrossBase.Log;

namespace CrossBase.Timers
{
    public class OneShotTimer : TimerBase
    {
        protected override ILogger Log
        {
            get { return SystemServices.LogManager.GetLogger("CrossBase.Timers.OneShotTimer"); }
        }

        public OneShotTimer(string name, int timeout, IDispatcher dispatcher) : 
            base(name, timeout, dispatcher)
        {
        }

        protected override void DoTick()
        {
            base.DoTick();
            Stop();
        }

    }
}
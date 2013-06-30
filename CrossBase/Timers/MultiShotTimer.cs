using System.Reflection;
using CrossBase.Dispatch;
using CrossBase.Log;

namespace CrossBase.Timers
{
    public class MultiShotTimer : TimerBase
    {
        protected override ILogger Log
        {
            get { return SystemServices.LogManager.GetLogger("CrossBase.Timers.MultiShotTimer"); }
        }

        public MultiShotTimer(string name, int timeout, IDispatcher dispatcher) : base(name, timeout, dispatcher)
        {
        }
    }
}
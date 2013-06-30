using System;
using System.Threading;
using CrossBase.Dispatch;
using CrossBase.Log;

namespace CrossBase.Timers
{
    public abstract class TimerBase : ITimer
    {
        protected abstract ILogger Log { get;}

        private bool enabled;
        private readonly Timer timer;

        protected TimerBase(string name, int timeout, IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
            Name = name;
            TimeOut = timeout;
            timer = new Timer(state => Dispatcher.BeginInvoke(DoTick), this, Timeout.Infinite, Timeout.Infinite);

        }
     
        public string Name { get; set; }
        public int TimeOut { get; set; }
        public IDispatcher Dispatcher { get; set; }
        public event Action Tick;

        public void Start()
        {
            if (enabled)
                return;
            enabled = true;
            timer.Change(TimeSpan.FromMilliseconds(TimeOut), TimeSpan.FromMilliseconds(TimeOut));

            Log.DebugFormat("{0} Timer started", Name);
            
        }

        public void Stop()
        {
            enabled = false;
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            Log.DebugFormat("{0} Timer stopped", Name);
        }

        public void Dispose()
        {
            if (enabled)
            {
                Stop();
            }
            timer.Dispose();
        }

   
        protected virtual void DoTick()
        {
            if (!enabled)
            {
                Log.DebugFormat("{0} Tick dropped", Name);
                return;
            }

            InvokeTick();
        }

        private void InvokeTick()
        {
            try
            {
                var handler = Tick;

                if (handler != null)
                {
                    handler();
                }
            }
            catch (Exception e)
            {
                Log.ErrorFormat("Exception occured while executing tick handler: {0}", e.Message);
            }
        }
    }
}
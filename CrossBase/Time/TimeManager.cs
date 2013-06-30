using System;

namespace CrossBase.Time
{
    public class TimeManager : ITimeManager
    {
        public SimulateTimeMode SimulationMode { get; private set; }
        public DateTime SimulationNow { get; private set; }
        private DateTime simulateNowRef;

        public void StartSimulation(SimulateTimeMode mode, DateTime now)
        {
            SimulationMode = mode;
            SimulationNow = now;
            simulateNowRef = DateTime.Now;
        }

        public void StopSimulation()
        {
            SimulationMode = SimulateTimeMode.Off;
        }

        public DateTime Now
        {
            get
            {
                switch (SimulationMode)
                {
                    case SimulateTimeMode.Off:
                        return DateTime.Now;
                    case SimulateTimeMode.Fixed:
                        return SimulationNow;
                    case SimulateTimeMode.Running:
                        return SimulationNow + (DateTime.Now - simulateNowRef);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public ulong NowMs
        {
            get { return (ulong)(Now.Ticks / TimeSpan.TicksPerMillisecond); }
        }

        public void Dispose()
        {
            
        }
    }
}
using System;

namespace CrossBase.Time
{
    public interface ITimeManager: IDisposable
    {
        SimulateTimeMode SimulationMode { get; }
        DateTime SimulationNow { get; }
        DateTime Now { get; }
        ulong NowMs { get; }
        void StartSimulation(SimulateTimeMode mode, DateTime now);
        void StopSimulation();
    }
}
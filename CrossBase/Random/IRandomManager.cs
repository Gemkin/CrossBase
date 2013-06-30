using System;

namespace CrossBase.Random
{
    public interface IRandomManager : IDisposable
    {
        int RandomNext(int max);
        SimulateRandomMode SimulateRandomMode { get; }
        bool SimulateRandom { get; }
        int SimulateRandomValue { get; }
        void StartSimulation(SimulateRandomMode mode, int value);
        void StopSimulation();
    }
}
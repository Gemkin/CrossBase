using System;

namespace CrossBase.Random
{
    public class DefaultRandomManager : IRandomManager
    {
        public SimulateRandomMode SimulateRandomMode { get; private set; }
        public bool SimulateRandom { get; private set; }
        public int SimulateRandomValue { get; private set; }

        public void StartSimulation(SimulateRandomMode mode, int value)
        {
            SimulateRandom = true;
            SimulateRandomMode = mode;
            SimulateRandomValue = value;
        }

        public void StopSimulation()
        {
            SimulateRandom = false;
        }

        private readonly System.Random random;

        public DefaultRandomManager()
        {
            random = new System.Random();
        }

        public int RandomNext(int max)
        {
            if (SimulateRandom)
            {
                switch (SimulateRandomMode)
                {
                    case SimulateRandomMode.Single:
                        return SimulateRandomValue;
                    case SimulateRandomMode.Increment:
                        return SimulateRandomValue++;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return random.Next(max);
        }

        public void Dispose()
        {
            
        }
    }
}
using CrossBase.Dispatch;
using CrossBase.Log;
using CrossBase.Random;
using CrossBase.Time;
using CrossBase.Timers;

namespace CrossBase.Platform.Shared
{
    public class SystemServicesConstructor : ISystemServicesConstructor
    {
        public void Construct()
        {
            SystemServices.DispatcherManager = new DispatcherManager();
            SystemServices.FileSystemManager = new FileSystemManager();
            SystemServices.LogManager = new DefaultLogManager();
            SystemServices.ObjectSerializer = new BinarySerializer();
            SystemServices.RandomManager = new DefaultRandomManager();
            SystemServices.ThreadManager = new ThreadManager();
            SystemServices.TimeManager = new TimeManager();
            SystemServices.TimerManager = new DefaultTimerManager();
        }

        public void Destruct()
        {
            SystemServices.DispatcherManager.Dispose();
            SystemServices.FileSystemManager.Dispose();
            SystemServices.LogManager.Dispose();
            SystemServices.ObjectSerializer.Dispose();
            SystemServices.RandomManager.Dispose();
            SystemServices.ThreadManager.Dispose();
            SystemServices.TimeManager.Dispose();
            SystemServices.TimerManager.Dispose();
        }
    }
}

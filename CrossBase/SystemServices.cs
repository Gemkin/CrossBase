using CrossBase.Dispatch;
using CrossBase.FileSystem;
using CrossBase.Log;
using CrossBase.Random;
using CrossBase.Threading;
using CrossBase.Time;
using CrossBase.Timers;

namespace CrossBase
{
    public static class SystemServices
    {
        public static IDispatcherManager DispatcherManager { get; set; }
        public static ITimeManager TimeManager { get; set; }
        public static ITimerManager TimerManager { get; set; }
        public static IFileSystemManager FileSystemManager { get; set; }
        public static ILogManager LogManager { get; set; }
        public static IRandomManager RandomManager { get; set; }
        public static IThreadManager ThreadManager { get; set; }
    }
}
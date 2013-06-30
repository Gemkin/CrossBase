using System;
using System.Threading;
using CrossBase.Threading;

namespace CrossBase.Platform.Shared
{
    public class ThreadManager : IThreadManager
    {
        public Thread Create(Action action)
        {
            return new Thread(() => action());
        }

        public Thread GetCurrentThread()
        {
            return Thread.CurrentThread;
        }

        public void Start(Thread thread)
        {
            thread.Start();
        }

        public void Join(Thread thread)
        {
            thread.Join();
        }

        public void Sleep(int i)
        {
            Thread.Sleep(i);
        }

        public int GetThreadId(Thread thread)
        {
            return thread.ManagedThreadId;
        }

        public void Dispose()
        {
            
        }
    }
}
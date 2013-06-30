using System;
using System.Threading;

namespace CrossBase.Threading
{
    public interface IThreadManager : IDisposable
    {
        Thread Create(Action action);
        Thread GetCurrentThread();
        void Start(Thread thread);
        void Join(Thread thread);
        void Sleep(int i);
        int GetThreadId(Thread thread);
    }
}
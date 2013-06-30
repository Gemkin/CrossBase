using System;

namespace CrossBase.Log
{
    public interface ILogManager : IDisposable
    {
        ILogger GetLogger(string name);
    }
}
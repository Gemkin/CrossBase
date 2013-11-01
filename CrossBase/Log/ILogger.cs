namespace CrossBase.Log
{
    public interface ILogger
    {
        object GetNativeLogger();
        void Error(string message);
        void ErrorFormat(string format, params object[] p);
        void Debug(string message);
        void DebugFormat(string format, params object[] p);
        void Warning(string message);
        void WarningFormat(string format, params object[] p);
        void Info(string message);
        void InfoFormat(string format, params object[] p);
    }
}
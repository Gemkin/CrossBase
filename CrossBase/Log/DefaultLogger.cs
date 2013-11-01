namespace CrossBase.Log
{
    public class DefaultLogger : ILogger
    {
        public object GetNativeLogger()
        {
            return new object();
        }
        public void Error(string message)
        {
        }

        public void ErrorFormat(string format, params object[] p)
        {
        }

        public void Debug(string message)
        {
        }

        public void DebugFormat(string format, params object[] p)
        {
        }

        public void Warning(string message)
        {
        }

        public void WarningFormat(string format, params object[] p)
        {
        }

        public void Info(string message)
        {
        }

        public void InfoFormat(string format, params object[] p)
        {
        }
    }
}
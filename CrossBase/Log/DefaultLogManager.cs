namespace CrossBase.Log
{
    public class DefaultLogManager : ILogManager
    {
        public ILogger GetLogger(string name)
        {
            return new DefaultLogger();
        }

        public void Dispose()
        {
            
        }
    }
}

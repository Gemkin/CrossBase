using System.Collections.Generic;

namespace CrossBase.Dispatch
{
    public class DispatcherManager: IDispatcherManager
    {
        private readonly Dictionary<DispatcherId, IDispatcher> dispatchers;

        public DispatcherManager()
        {
            dispatchers = new Dictionary<DispatcherId, IDispatcher>();
        }

        public IDispatcher this[DispatcherId id]
        {
            get { return dispatchers[id]; }
        }

        public void Register(IDispatcher dispatcher)
        {
            dispatchers.Add(dispatcher.Id, dispatcher);
        }

        public void Unregister(IDispatcher dispatcher)
        {
            dispatchers.Remove(dispatcher.Id);
        }

        public void Dispose()
        {
            foreach (var dispatcher in dispatchers.Values)
            {
                dispatcher.Dispose();
            }
            dispatchers.Clear();
        }
    }
}
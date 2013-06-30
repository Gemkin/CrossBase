using System;
using System.Collections.Generic;
using System.Threading;

namespace CrossBase.Dispatch
{
    public class ManualDispatcher : IDispatcher
    {
        private readonly Queue<Action> actions = new Queue<Action>();

        public ManualDispatcher(DispatcherId id)
        {
            Id = id;
        }

        public int ThreadId
        {
            get { return Thread.CurrentThread.ManagedThreadId; }
        }

        public DispatcherId Id
        {
            get;
            private set;
        }

        public bool ActionsRemaining
        {
            get { return actions.Count > 0; }
        }

        public void BeginInvoke(Action methodToExecute)
        {
            actions.Enqueue(methodToExecute);
        }

        public void Invoke(Action methodToExecute)
        {
            methodToExecute();
        }

        public void Dispose()
        {
        }

        public void Next()
        {
            if (actions.Count > 0)
                actions.Dequeue()();
        }
    }
}
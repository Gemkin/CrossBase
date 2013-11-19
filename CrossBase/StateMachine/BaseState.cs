namespace CrossBase.StateMachine
{
    public abstract class BaseState<P, Q, R> : IState
        where P : IStateMachine<R> where R : StateEvent
        where Q : IStateContext
    {
        public Q Context { get; set; }
        public P Machine { get; set; }

        public virtual void Enter()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
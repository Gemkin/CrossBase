namespace CrossBase.StateMachine
{
    public abstract class BaseState<TStateMachine, TStateContext, TStateEvent> : IState
        where TStateMachine : IStateMachine<TStateEvent> where TStateEvent : StateEvent
        where TStateContext : IStateContext
    {
        public TStateContext Context { get; set; }
        public TStateMachine Machine { get; set; }

        public virtual void Enter()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
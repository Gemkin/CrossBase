namespace CrossBase.StateMachine
{
    public interface IStateMachine<in S>
    {
        /// <summary>
        /// Handles state events asynchroniously on the logic dispatcher
        /// </summary>
        /// <param name="stateEvent"></param>
        void HandleEvent(S stateEvent);
    }
}
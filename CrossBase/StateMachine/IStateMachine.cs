namespace CrossBase.StateMachine
{
    /// <summary>
    /// Interface for StateMachine
    /// </summary>
    /// <typeparam name="TStateEvent">StateEvent type</typeparam>
    public interface IStateMachine<in TStateEvent>
    {
        /// <summary>
        /// Handles state events asynchroniously on the logic dispatcher
        /// </summary>
        /// <param name="stateEvent">Event to handle</param>
        void HandleEvent(TStateEvent stateEvent);
    }
}
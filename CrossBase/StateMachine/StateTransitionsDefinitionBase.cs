using System;

namespace CrossBase.StateMachine
{
    public abstract class StateTransitionsDefinitionBase
    {
        public abstract StateTransistion[] Normal { get; }
        public abstract StateTransistion[] Special { get; }
        public abstract Type InitialStateType { get; }
    }
}
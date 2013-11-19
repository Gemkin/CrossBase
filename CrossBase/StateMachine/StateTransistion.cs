using System;

namespace CrossBase.StateMachine
{
    public class StateTransistion
    {
        public Type Current { get; set; }
        public Type Next { get; set; }
        public StateEvent Event { get; set; }
    }
}
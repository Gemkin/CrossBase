using System;

namespace CrossBase.StateMachine
{
    public class StateChangedEventArgsBase : EventArgs
    {
        public IState PrevState { get; set; }
        public IState NextState { get; set; }
        public StateEvent StateEvent { get; set; }
    }
}
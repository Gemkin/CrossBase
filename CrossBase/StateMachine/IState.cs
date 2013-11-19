using System;

namespace CrossBase.StateMachine
{
    public interface IState: IDisposable
    {
        void Enter();
    }
}
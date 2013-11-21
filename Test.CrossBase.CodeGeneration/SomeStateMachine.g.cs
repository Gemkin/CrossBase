/**************************************************************************
AUTOMATIC GENERATED FILE! DO NOT CHANGE MANUALLY 		
CrossBase.CodeGeneration
Wies Hubbers
**************************************************************************/
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantUsingDirective
// ReSharper disable SuspiciousTypeConversion.Global
// ReSharper disable RedundantCast
#pragma warning disable 649
#pragma warning disable 183

using System;
using CrossBase.StateMachine;
using CrossBase.Dispatch;
using CrossBase.Log;
using Test.CrossBase.CodeGeneration;
using CrossBase.CodeGeneration.Attributes;

namespace Test.CrossBase.CodeGeneration	
{
    public partial class SomeStateMachine: StateMachineBase< SomeStateMachineContext,  
                                                                      SomeStateMachineTransitions, 
                                                                      SomeStateMachineStateChangedEventArgs, 
                                                                      SomeStateMachineStateEvent>
    {
        public SomeStateMachine(ILogger log, IDispatcher dispatcher, SomeStateMachineContext context) : base(log, dispatcher, context)
        {
        }

        protected override void OnEnteringNextState(SomeStateMachineStateChangedEventArgs e)
        {
            base.OnEnteringNextState(e);
            if(e.PrevState is IdleState)
            {
                OnIdleStateLeave(new  IdleStateEventArgs {  IdleState = e.PrevState as  IdleState, Event = (SomeStateMachineStateEvent)e.StateEvent });
            }
                        
            else if(e.PrevState is WaitState)
            {
                OnWaitStateLeave(new  WaitStateEventArgs {  WaitState = e.PrevState as  WaitState, Event = (SomeStateMachineStateEvent)e.StateEvent });
            }
                        
            else if(e.PrevState is RunState)
            {
                OnRunStateLeave(new  RunStateEventArgs {  RunState = e.PrevState as  RunState, Event = (SomeStateMachineStateEvent)e.StateEvent });
            }
                        
            if(e.NextState is IdleState)
            {
                OnIdleStateEnter(new  IdleStateEventArgs {  IdleState = e.NextState as  IdleState, Event = (SomeStateMachineStateEvent)e.StateEvent });
            }
                        
            else if(e.NextState is WaitState)
            {
                OnWaitStateEnter(new  WaitStateEventArgs {  WaitState = e.NextState as  WaitState, Event = (SomeStateMachineStateEvent)e.StateEvent });
            }
                        
            else if(e.NextState is RunState)
            {
                OnRunStateEnter(new  RunStateEventArgs {  RunState = e.NextState as  RunState, Event = (SomeStateMachineStateEvent)e.StateEvent });
            }
                        
        }

        public event EventHandler<IdleStateEventArgs> IdleStateLeave;
        protected virtual void OnIdleStateLeave(IdleStateEventArgs e)
        {
            var handler = IdleStateLeave;
            if (handler != null) handler(this, e);
        }
        public event EventHandler<IdleStateEventArgs> IdleStateEnter;
        protected virtual void OnIdleStateEnter(IdleStateEventArgs e)
        {
            var handler = IdleStateEnter;
            if (handler != null) handler(this, e);
        }
        public event EventHandler<WaitStateEventArgs> WaitStateLeave;
        protected virtual void OnWaitStateLeave(WaitStateEventArgs e)
        {
            var handler = WaitStateLeave;
            if (handler != null) handler(this, e);
        }
        public event EventHandler<WaitStateEventArgs> WaitStateEnter;
        protected virtual void OnWaitStateEnter(WaitStateEventArgs e)
        {
            var handler = WaitStateEnter;
            if (handler != null) handler(this, e);
        }
        public event EventHandler<RunStateEventArgs> RunStateLeave;
        protected virtual void OnRunStateLeave(RunStateEventArgs e)
        {
            var handler = RunStateLeave;
            if (handler != null) handler(this, e);
        }
        public event EventHandler<RunStateEventArgs> RunStateEnter;
        protected virtual void OnRunStateEnter(RunStateEventArgs e)
        {
            var handler = RunStateEnter;
            if (handler != null) handler(this, e);
        }
	}
}

// ReSharper restore PartialMethodWithSinglePart
// ReSharper restore RedundantNameQualifier
// ReSharper restore RedundantUsingDirective
// ReSharper restore SuspiciousTypeConversion.Global
// ReSharper restore RedundantCast
#pragma warning restore 649
#pragma warning restore 183

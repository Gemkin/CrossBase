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
using Test.CrossBase.CodeGeneration;
using CrossBase.CodeGeneration.Attributes;
using CrossBase.StateMachine;

namespace Test.CrossBase.CodeGeneration	
{
    public class SomeStateMachineTransitions : StateTransitionsDefinitionBase
    {
        public override StateTransistion[] Normal
        {
            get 
            {
             
                return new [] 
                {
                    new StateTransistion{ Current = typeof(IdleState), Event = SomeStateMachineStateEvent.Init, Next = typeof(WaitState) },
                    new StateTransistion{ Current = typeof(WaitState), Event = SomeStateMachineStateEvent.Go, Next = typeof(RunState) },
                    new StateTransistion{ Current = typeof(RunState), Event = SomeStateMachineStateEvent.Done, Next = typeof(IdleState) },

                };
                 
            }
        }

        public override StateTransistion[] Special
        {
            get 
            {
             
                return new [] 
                {
                    new StateTransistion{ Event = SomeStateMachineStateEvent.Stop, Next = typeof(IdleState) },

                };
                 
            }
        }
        }

        public override Type InitialStateType
        {
            get { return typeof(IdleState); }
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

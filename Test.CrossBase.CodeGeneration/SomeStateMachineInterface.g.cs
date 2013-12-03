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
    public interface ISomeStateMachine: IStateMachine<SomeStateMachineStateEvent>
    {

        event EventHandler<IdleStateEventArgs> IdleStateLeave;
        event EventHandler<IdleStateEventArgs> IdleStateEnter;
        event EventHandler<WaitStateEventArgs> WaitStateLeave;
        event EventHandler<WaitStateEventArgs> WaitStateEnter;
        event EventHandler<RunStateEventArgs> RunStateLeave;
        event EventHandler<RunStateEventArgs> RunStateEnter;
	}
}

// ReSharper restore PartialMethodWithSinglePart
// ReSharper restore RedundantNameQualifier
// ReSharper restore RedundantUsingDirective
// ReSharper restore SuspiciousTypeConversion.Global
// ReSharper restore RedundantCast
#pragma warning restore 649
#pragma warning restore 183

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
    public class SomeStateMachineStateEvent : StateEvent
    {
        public static SomeStateMachineStateEvent Init { get;  private set; }
        public static SomeStateMachineStateEvent Go { get;  private set; }
        public static SomeStateMachineStateEvent Done { get;  private set; }
        public static SomeStateMachineStateEvent Stop { get;  private set; }
        static SomeStateMachineStateEvent()
        {
            Init = new SomeStateMachineStateEvent("Init");
            Go = new SomeStateMachineStateEvent("Go");
            Done = new SomeStateMachineStateEvent("Done");
            Stop = new SomeStateMachineStateEvent("Stop");

        }

        private SomeStateMachineStateEvent(string name) : base(name)
        {
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

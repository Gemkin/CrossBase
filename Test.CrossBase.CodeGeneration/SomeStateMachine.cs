using System;
using CrossBase.CodeGeneration.Attributes;
using CrossBase.StateMachine;

namespace Test.CrossBase.CodeGeneration
{

    [StateMachine(InitState   = "Idle",
                  Special     = "Stop -> Idle;",
                            
                  Transitions = "Idle | Init -> Wait;" +
                                "Wait | Go   -> Run;" +
                                "Run  | Done -> Idle")]
    public partial class SomeStateMachine
    {
      
    }

}

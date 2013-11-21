using System;

namespace CrossBase.CodeGeneration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class StateMachineAttribute : Attribute
    {
        public string InitState { get; set; }
        public string Transitions{ get; set; }
        public string Special{ get; set; }
    }
}
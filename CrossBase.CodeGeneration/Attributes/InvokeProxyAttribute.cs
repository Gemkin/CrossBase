using System;

namespace CrossBase.CodeGeneration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InvokeProxyAttribute : Attribute
    {
        public string InterfaceName { get; set; }
        public string ClassName { get; set; }
    }
}
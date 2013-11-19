using System;

namespace CrossBase.CodeGeneration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DispatchProxyAttribute : Attribute
    {
        public string InterfaceName { get; set; }
        public string ClassName { get; set; }
    }
}
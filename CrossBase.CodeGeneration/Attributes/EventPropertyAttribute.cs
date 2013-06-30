using System;

namespace CrossBase.CodeGeneration.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EventPropertyAttribute : Attribute
    {
        public const string NotifyPropertyAndEventProperty = "NotifyPropertyAndEventProperty";
        public const string EventPropertyOnly = "EventPropertyOnly";
        public const string NotifyPropertyOnly = "NotifyPropertyOnly";

        public bool GenerateAlwaysUpdate { get; set; }
        public bool GenerateSetters { get; set; }
        public string GenerationMode { get; set; }
    }

}

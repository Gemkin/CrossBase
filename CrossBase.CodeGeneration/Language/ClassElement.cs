using System.Collections.Generic;

namespace CrossBase.CodeGeneration.Language
{
    public abstract class ClassElement : AccessControlledElement
    {
        protected ClassElement()
        {
            Namespace = new Namespace();
            Functions = new List<Function>();
            Properties = new List<Property>();
            Events = new List<Event>();
        }

        public List<Namespace> Usings { get; set; }
        public Namespace Namespace { get; set; }
        public List<Property> Properties { get; set; }
        public List<Function> Functions { get; set; }
        public List<Event> Events { get; set; }
    }
}
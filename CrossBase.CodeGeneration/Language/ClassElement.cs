using System.Collections.Generic;

namespace CrossBase.CodeGeneration.Language
{
    public abstract class ClassElement : AccessControlledElement
    {
        public List<Event> AllEvents
        {
            get
            {
                var allEvents = new List<Event>(Events);
                foreach (var interfaceBase in InterfaceBases)
                {
                    allEvents.AddRange(interfaceBase.Events);
                }
                return allEvents;
            }
        }

        public List<Function> AllFunctions
        {
            get
            {
                var all = new List<Function>(Functions);
                foreach (var interfaceBase in InterfaceBases)
                {
                    all.AddRange(interfaceBase.Functions);
                }
                return all;
            }
        }

        public List<Property> AllProperties
        {
            get
            {
                var all = new List<Property>(Properties);
                foreach (var interfaceBase in InterfaceBases)
                {
                    all.AddRange(interfaceBase.Properties);
                }
                return all;
            }
        }
        protected ClassElement()
        {
            Namespace = new Namespace();
            Functions = new List<Function>();
            Properties = new List<Property>();
            Events = new List<Event>();
            InterfaceBases = new List<Interface>();
        }

        public List<Namespace> Usings { get; set; }
        public Namespace Namespace { get; set; }
        public List<Property> Properties { get; set; }
        public List<Function> Functions { get; set; }
        public List<Event> Events { get; set; }
        public List<Interface> InterfaceBases { get; set; }
    }
}
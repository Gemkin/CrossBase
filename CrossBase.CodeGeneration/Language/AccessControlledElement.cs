using System.Collections.Generic;

namespace CrossBase.CodeGeneration.Language
{
    public abstract class AccessControlledElement:TypedElement
    {
        public List<Attribute> Attributes { get; set; }

        public Access Access { get; set; }
    
        protected AccessControlledElement()
        {
            Access = Access.Public;
            Attributes = new List<Attribute>();
        }
    }
}
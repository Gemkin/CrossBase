using System;

namespace CrossBase.CodeGeneration.Language
{
    public class Property: AccessControlledElement
    {
        public string FileName { get; set; }
        public bool HasSetter { get; set; }
    }
}

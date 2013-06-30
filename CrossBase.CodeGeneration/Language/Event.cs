namespace CrossBase.CodeGeneration.Language
{
    public class Event: TypedElement
    {
        private const string SystemEventhandlerPrefix = "System.EventHandler<";
        public Access Access { get; set; }
        public string FileName { get; set; }

        public bool IsGenericEventHandler
        {
            get { return Name.StartsWith(SystemEventhandlerPrefix); }
        }

        public string GenericEventHandlerType
        {
            get
            {
                return Type.Substring(SystemEventhandlerPrefix.Length, Type.Length - SystemEventhandlerPrefix.Length - 1); 
            }
        }

    }
}
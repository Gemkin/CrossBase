namespace CrossBase.CodeGeneration.Language
{
    public abstract class TypedElement
    {
        

        public string Name { get; set; }
        public string Type { get; set; }
        
        protected TypedElement()
        {
            Name = string.Empty;
            Type = string.Empty;
        }
    }
}
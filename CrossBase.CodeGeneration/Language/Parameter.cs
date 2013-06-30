namespace CrossBase.CodeGeneration.Language
{
    public class Parameter:TypedElement
    {
        public Modifier Modifier { get; set; }

        public Parameter()
        {
            Modifier = Modifier.In;
        }

        public override string ToString()
        {
            return Signature();
        }

        private string Signature()
        {
            return string.Format("{0} {1}", Type, Name);
        }

        public string CallSignature()
        {
            return string.Format("{0}", Name);
        }

    }
}
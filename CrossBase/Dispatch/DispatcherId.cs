namespace CrossBase.Dispatch
{
    public class DispatcherId
    {
        public static readonly DispatcherId Logic = new DispatcherId("logicDispatcher");
        public static readonly DispatcherId Ui = new DispatcherId("uiDispatcher");

        private readonly string name;

        protected DispatcherId(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
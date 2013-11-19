namespace CrossBase.StateMachine
{
    public abstract class StateEvent
    {
        private readonly string name;

        protected StateEvent(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
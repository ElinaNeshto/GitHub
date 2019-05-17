namespace to.Storage
{
    [System.Serializable]
    public class Incorrectlr1DataException : System.Exception
    {
        public Incorrectlr1DataException() { }
        public Incorrectlr1DataException(string message) : base(message) { }
        public Incorrectlr1DataException(string message, System.Exception inner) : base(message, inner) { }
        protected Incorrectlr1DataException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
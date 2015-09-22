namespace ChainOfResponsibilityDemo
{
    public abstract class Handler
    {
        public Handler()
        {
        }

        public Handler(Handler successor)
        {
            this.Successor = successor;
        }

        protected Handler Successor { get; set; }

        public abstract void ProcessRequest(int number);
    }
}

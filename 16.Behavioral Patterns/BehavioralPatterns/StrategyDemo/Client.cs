namespace StrategyDemo
{
    public class Client
    {
        public Client(IStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public IStrategy Strategy { get; private set; }

        public void ExecuteStrategy(string inputText)
        {
            this.Strategy.DoOperation(inputText);
        }
    }
}

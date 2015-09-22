namespace StrategyDemo
{
    using System;

    public class ConcreteStrategy2 : IStrategy
    {
        public void DoOperation(string inputString)
        {
            Console.WriteLine("The operation done using concrete strategy 2.");
        }
    }
}
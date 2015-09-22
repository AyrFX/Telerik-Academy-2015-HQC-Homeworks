namespace ChainOfResponsibilityDemo
{
    using System;

    internal class ConcreteHandler1 : Handler
    {
        public override void ProcessRequest(int number)
        {
            if (number <= 10)
            {
                Console.WriteLine("The request is handled by ConcreteHandler1.");
            }
            else
            {
                if (this.Successor != null)
                {
                    Successor.ProcessRequest(number);
                }
            }
        }
    }
}

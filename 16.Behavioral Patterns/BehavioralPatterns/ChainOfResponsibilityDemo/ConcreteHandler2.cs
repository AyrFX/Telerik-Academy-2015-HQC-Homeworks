namespace ChainOfResponsibilityDemo
{
    using System;

    internal class ConcreteHandler2 : Handler
    {
        public override void ProcessRequest(int number)
        {
            if (number <= 20)
            {
                Console.WriteLine("The request is handled by ConcreteHandler2.");
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

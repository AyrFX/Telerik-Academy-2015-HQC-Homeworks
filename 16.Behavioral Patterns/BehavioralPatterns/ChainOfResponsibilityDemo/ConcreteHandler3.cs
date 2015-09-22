namespace ChainOfResponsibilityDemo
{
    using System;

    internal class ConcreteHandler3 : Handler
    {
        public override void ProcessRequest(int number)
        {
            if (number <= 30)
            {
                Console.WriteLine("The request is handled by ConcreteHandler3.");
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

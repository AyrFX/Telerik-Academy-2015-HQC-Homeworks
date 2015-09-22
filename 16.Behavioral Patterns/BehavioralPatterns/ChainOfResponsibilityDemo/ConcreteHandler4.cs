namespace ChainOfResponsibilityDemo
{
    using System;

    internal class ConcreteHandler4 : Handler
    {
        public override void ProcessRequest(int number)
        {
            if (number <= 40)
            {
                Console.WriteLine("The request is handled by ConcreteHandler1.");
            }
            else
            {
                Console.WriteLine("The request can't be processed!");
            }
        }
    }
}

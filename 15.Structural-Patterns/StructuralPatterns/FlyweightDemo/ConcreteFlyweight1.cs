namespace FlyweightDemo
{
    using System;

    internal class ConcreteFlyweight1 : Flyweight
    {
        public ConcreteFlyweight1()
        {
            this.FlyweightProperty1 = 1;
            this.FlyweightProperty2 = "one";
            this.FlyweightProperty3 = 'A';
        }

        public override void FlyweightMethod(int property1Value)
        {
            Console.WriteLine("Concrete Flyweight 1 with propertyValue = {0}", property1Value);
        }
    }
}

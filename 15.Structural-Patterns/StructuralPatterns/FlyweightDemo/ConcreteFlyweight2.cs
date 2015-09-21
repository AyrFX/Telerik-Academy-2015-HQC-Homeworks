namespace FlyweightDemo
{
    using System;

    internal class ConcreteFlyweight2 : Flyweight
    {
        public ConcreteFlyweight2()
        {
            this.FlyweightProperty1 = 2;
            this.FlyweightProperty2 = "two";
            this.FlyweightProperty3 = 'B';
        }

        public override void FlyweightMethod(int property1Value)
        {
            Console.WriteLine("Concrete Flyweight 2 with propertyValue = {0}", property1Value);
        }
    }
}

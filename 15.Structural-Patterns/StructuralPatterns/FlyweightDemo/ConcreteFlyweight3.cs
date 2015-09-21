namespace FlyweightDemo
{
    using System;

    internal class ConcreteFlyweight3 : Flyweight
    {
        public ConcreteFlyweight3()
        {
            this.FlyweightProperty1 = 3;
            this.FlyweightProperty2 = "three";
            this.FlyweightProperty3 = 'C';
        }

        public override void FlyweightMethod(int property1Value)
        {
            Console.WriteLine("Concrete Flyweight 3 with propertyValue = {0}", property1Value);
        }
    }
}

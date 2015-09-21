namespace FlyweightDemo
{
    public abstract class Flyweight
    {
        protected int FlyweightProperty1 { get; set; }

        protected string FlyweightProperty2 { get; set; }

        protected char FlyweightProperty3 { get; set; }

        public abstract void FlyweightMethod(int property1Value);
    }
}

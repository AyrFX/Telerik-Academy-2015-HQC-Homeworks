namespace IteratorDemo
{
    using System;

    public class ConcreteAggregate : IAggregate
    {
        private int[] items;

        public int Length
        {
            get
            {
                return this.items.Length;
            }
        }

        public object this[int index]
        {
            get
            {
                return this.items[index];
            }
        }

        public IIterator GetIterator()
        {
            return new ConcreteIterator(this);
        }
    }
}

namespace IteratorDemo
{
    public class ConcreteIterator : IIterator
    {
        private ConcreteAggregate aggregate;

        private int current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public void Next()
        {
            this.current++;
        }

        public object CurrentItem()
        {
            return this.aggregate[this.current];
        }

        public bool IsDone()
        {
            return this.current >= this.aggregate.Length;
        }
    }
}

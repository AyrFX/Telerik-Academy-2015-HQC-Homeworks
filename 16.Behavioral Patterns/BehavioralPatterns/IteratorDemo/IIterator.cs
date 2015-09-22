namespace IteratorDemo
{
    public interface IIterator
    {
        void Next();

        bool IsDone();

        object CurrentItem();
    }
}

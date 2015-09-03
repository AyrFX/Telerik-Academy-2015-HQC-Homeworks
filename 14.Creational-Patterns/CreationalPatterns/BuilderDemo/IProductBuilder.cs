namespace BuilderDemo
{
    public interface IProductBuilder
    {
        void SetProperty1(int value);

        void SetProperty2(string value);

        Product GetResult();
    }
}

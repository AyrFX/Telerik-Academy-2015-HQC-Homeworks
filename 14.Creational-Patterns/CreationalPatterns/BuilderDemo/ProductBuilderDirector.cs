namespace BuilderDemo
{
    public class ProductBuilderDirector
    {
        public Product Construct()
        {
            ProductBuilder builder = new ProductBuilder();

            builder.SetProperty1(4);
            builder.SetProperty2("Some property vale");

            return builder.GetResult();
        }
    }
}

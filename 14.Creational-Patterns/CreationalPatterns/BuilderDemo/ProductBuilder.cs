namespace BuilderDemo
{
    public class ProductBuilder : IProductBuilder
    {
        private Product product;

        public ProductBuilder()
        {
            this.product = new Product();
        }

        public void SetProperty1(int value)
        {
            this.product.ProductProperty1 = value;
        }

        public void SetProperty2(string value)
        {
            this.product.ProductProperty2 = value;
        }

        public Product GetResult()
        {
            return this.product;
        }
    }
}

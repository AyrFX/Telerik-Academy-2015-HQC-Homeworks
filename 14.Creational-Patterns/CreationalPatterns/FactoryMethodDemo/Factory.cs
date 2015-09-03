namespace FactoryMethodDemo
{
    public enum ProductType
    {
        ProductType1,
        ProductType2
    }

    public class Factory
    {
        public IProduct CreateProduct(ProductType type)
        {
            IProduct product = null;
            switch (type)
            {
                case ProductType.ProductType1:
                    product = new ConcreteProduct1();
                    break;
                case ProductType.ProductType2:
                    product = new ConcreteProduct2();
                    break;
                default:
                    break;
            }

            return product;
        }
    }
}

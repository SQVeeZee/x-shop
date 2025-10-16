namespace Shop
{
    public class PayloadProduct : IPayload
    {
        public ProductConfig Config { get; private set; }

        public PayloadProduct(ProductConfig config) => Config = config;
    }
}
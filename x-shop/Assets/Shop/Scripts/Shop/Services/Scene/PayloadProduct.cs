namespace Shop
{
    public class PayloadProduct : IPayload
    {
        public InfoData InfoData { get; private set; }

        public PayloadProduct(InfoData data) => InfoData = data;
    }
}
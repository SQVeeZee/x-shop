namespace Shop
{
    public readonly struct PurchaseData
    {
        public ProductConfig ProductConfig { get; }
        public IPurchaseListener PurchaseListener { get; }

        public PurchaseData(ProductConfig productConfig, IPurchaseListener purchaseListener)
        {
            ProductConfig = productConfig;
            PurchaseListener = purchaseListener;
        }
    }
}
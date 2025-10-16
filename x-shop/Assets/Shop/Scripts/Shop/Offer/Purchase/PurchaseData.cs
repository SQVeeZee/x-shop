namespace Shop
{
    public readonly struct PurchaseData
    {
        public ProductConfig ProductConfig { get; }
        public IPurchasable Purchasable { get; }

        public PurchaseData(ProductConfig productConfig, IPurchasable purchaseListener)
        {
            ProductConfig = productConfig;
            Purchasable = purchaseListener;
        }
    }
}
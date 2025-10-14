namespace Shop
{
    public readonly struct InfoData
    {
        public ProductConfig ProductConfig { get; }
        public IInfoListener Listener { get; }

        public InfoData(ProductConfig productConfig, IInfoListener listener)
        {
            ProductConfig = productConfig;
            Listener = listener;
        }
    }
}
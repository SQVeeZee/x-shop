namespace Shop
{
    public readonly struct ProductCardData
    {
        public ProductConfig Config { get; }
        public ShopCard Card { get; }

        public ProductCardData(ProductConfig productConfig, ShopCard shopCard)
        {
            Config = productConfig;
            Card = shopCard;
        }
    }
}
namespace Shop
{
    public readonly struct DescriptionData
    {
        public ProductConfig ProductConfig { get; }
        public IDescription CurrencyDescription { get; }

        public DescriptionData(ProductConfig productConfig, IDescription currencyDescription)
        {
            ProductConfig = productConfig;
            CurrencyDescription = currencyDescription;
        }
    }
}
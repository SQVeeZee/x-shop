namespace Shop
{
    public readonly struct ProductCheatData
    {
        public ProductConfig Config { get; }
        public CheatView View { get; }

        public ProductCheatData(ProductConfig productConfig, CheatView cheatView)
        {
            Config = productConfig;
            View = cheatView;
        }
    }
}
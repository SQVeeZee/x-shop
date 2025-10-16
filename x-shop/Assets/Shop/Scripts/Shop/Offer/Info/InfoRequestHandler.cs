namespace Shop
{
    public class InfoRequestHandler : ShopProductHandler<IInformational>
    {
        private readonly SceneService _sceneService;

        public InfoRequestHandler(int amount) : base(amount)
            => _sceneService = SceneService.Instance;

        protected override void OnAddedProduct(HandlerInfo<IInformational> productCardData)
        {
            var productConfig = productCardData.Config;
            var informational = productCardData.View;
            informational.Initialize(() => LoadSceneWithPayLoad(productConfig));
        }

        private void LoadSceneWithPayLoad(ProductConfig productConfig)
            => _sceneService.LoadSceneWithPayload(SceneService.ShopCardScene, new PayloadProduct(productConfig));

        protected override void DisposeProduct(IInformational productCardData) => productCardData.Release();

        public override void Release()
        {
            foreach (var productCard in ProductCards)
            {
                productCard.View.Release();
            }
            ProductCards.Clear();
        }
    }
}
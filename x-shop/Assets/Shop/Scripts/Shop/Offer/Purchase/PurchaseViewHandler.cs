using JetBrains.Annotations;
using Shop.Core;

namespace Shop
{
    public class PurchasableViewHandler : ShopProductHandler<IPurchasable>
    {
        private readonly PlayerData _playerData;
        private readonly PurchaseService _purchaseService;

        [UsedImplicitly]
        public PurchasableViewHandler(int amount) : base(amount)
        {
            _playerData = PlayerData.Instance;
            _purchaseService = PurchaseService.Instance;
        }

        protected override void OnAddedProduct(HandlerInfo<IPurchasable> productCardData)
        {
            var purchasable = productCardData.View;
            purchasable.Initialize(handler);
            return;
            void handler() => CardBuyClickHandler(purchasable, productCardData.Config);

        }

        protected override void DisposeProduct(IPurchasable productCardData) => productCardData.Release();

        public override void Release()
        {
            foreach (var productCardData in ProductCards)
            {
                productCardData.View.Release();
            }
            ProductCards.Clear();
        }

        private void CardBuyClickHandler(IPurchasable purchasable, ProductConfig productConfig)
        {
            if (_purchaseService.InProgress)
            {
                return;
            }
            purchasable.SetProgressState(BuyingState.Processing);
            _purchaseService.TryApplyTransactionWithDelay(_playerData, productConfig, resetState);
            return;

            void resetState() => purchasable.SetProgressState(BuyingState.Ready);
        }
    }
}
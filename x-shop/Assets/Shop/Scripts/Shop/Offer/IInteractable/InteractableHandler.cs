using Shop.Core;

namespace Shop
{
    public class InteractableHandler : ShopProductHandler<IInteractable>
    {
        private readonly PlayerData _playerData;
        private readonly PurchaseService _purchaseService;

        public InteractableHandler(int amount) : base(amount)
        {
            _playerData = PlayerData.Instance;
            _purchaseService = PurchaseService.Instance;

            _purchaseService.OnPurchased += PurchaseHandler;
        }

        protected override void OnAddedProduct(HandlerInfo<IInteractable> productCardData)
            => UpdateInteractableState(productCardData);


        public override void Release()
        {
            ProductCards.Clear();
            _purchaseService.OnPurchased -= PurchaseHandler;
        }

        private void CheckProducts()
        {
            foreach (var interactableData in ProductCards)
            {
                UpdateInteractableState(interactableData);
            }
        }

        private void UpdateInteractableState(HandlerInfo<IInteractable> productCardData)
        {
            var costs = productCardData.Config.GetCostsOperations();
            foreach (var costOperation in costs)
            {
                if (costOperation.CanAfford(_playerData))
                {
                    continue;
                }
                productCardData.View.SetState(false);
                return;
            }
            productCardData.View.SetState(true);
        }

        private void PurchaseHandler() => CheckProducts();
    }
}
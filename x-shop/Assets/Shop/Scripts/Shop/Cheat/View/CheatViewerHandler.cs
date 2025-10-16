using Shop.Core;

namespace Shop
{
    public class CheatViewHandler : CheatHandler<ICheatViewer>
    {
        private readonly PlayerData _playerData;
        private readonly PurchaseService _purchaseService;

        public CheatViewHandler(int amount) : base(amount)
        {
            _purchaseService = PurchaseService.Instance;
            _playerData = PlayerData.Instance;

            _purchaseService.OnPurchased += PurchaseHandle;
        }

        protected override void OnAddedProduct(HandlerInfo<ICheatViewer> productCardData)
            => SetViewer(productCardData.View, productCardData.Config);

        public override void Release()
        {
            CheatViews.Clear();
            _purchaseService.OnPurchased -= PurchaseHandle;
        }

        private void PurchaseHandle() => UpdateViewers();

        private void UpdateViewers()
        {
            foreach (var cheatView in CheatViews)
            {
                if (!GetConfigElement(cheatView.Config, out var config))
                {
                    return;
                }
                var value = config.GetValue(_playerData);
                cheatView.View.UpdateCurrency(value);
            }
        }

        private void SetViewer(ICheatViewer viewer, ProductConfig productConfig)
        {
            if (!GetConfigElement(productConfig, out var config))
            {
                return;
            }
            var reward = config.GetValue(_playerData);
            viewer.SetCurrency(config.Currency, reward);
        }

        private bool GetConfigElement(ProductConfig productConfig, out CurrencyConfigBase config)
        {
            var costs = productConfig.Costs;
            if (costs.Length > 0)
            {
                config = costs[0];
                return true;
            }
            var rewards = productConfig.Rewards;
            if (rewards.Length > 0)
            {
                config = rewards[0];
                return true;
            }

            config = null;
            return false;
        }
    }
}
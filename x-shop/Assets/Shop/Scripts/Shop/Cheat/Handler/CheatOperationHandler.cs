using JetBrains.Annotations;
using Shop.Core;

namespace Shop
{
    public sealed class CheatOperationHandler : CheatHandler<ICheatOperation>
    {
        private readonly PlayerData _playerData;
        private readonly PurchaseService _purchaseService;

        [UsedImplicitly]
        public CheatOperationHandler(int amount) : base(amount)
        {
            _playerData = PlayerData.Instance;
            _purchaseService = PurchaseService.Instance;
        }

        protected override void OnAddedProduct(HandlerInfo<ICheatOperation> productCardData)
            => productCardData.View.Initialize(() => CheatOperationHandle(productCardData.Config));

        private void CheatOperationHandle(ProductConfig config)
        {
            if (_purchaseService.InProgress)
            {
                return;
            }
            if (CanAfford(config))
            {
                _purchaseService.TryApplyTransaction(_playerData, config);
            }
        }

        private bool CanAfford(ProductConfig config)
        {
            var costs = config.GetCostsOperations();
            foreach (var costOperation in costs)
            {
                if (costOperation.CanAfford(_playerData))
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        public override void Release()
        {
            foreach (var cheatView in CheatViews)
            {
                cheatView.View.Release();
            }
            CheatViews.Clear();
        }
    }
}
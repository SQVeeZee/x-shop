using Shop.Core;

namespace Shop
{
    public readonly struct TransactionSolver
    {
        private readonly ProductConfig _productConfig;

        public TransactionSolver(ProductConfig productConfig) => _productConfig = productConfig;

        public bool TryApplyTransaction(PlayerData playerData)
        {
            var costs = _productConfig.GetCosts();
            if(!IsEnoughCurrency(playerData, costs))
            {
                return false;
            }
            var rewards = _productConfig.GetRewards();
            ApplyTransaction(playerData, costs, rewards);
            return true;
        }

        private static void ApplyTransaction(PlayerData playerData, ICostOperation[] costs, IRewardOperation[] rewards)
        {
            SpendCurrency(playerData, costs);
            ApplyRewards(playerData, rewards);
        }

        private static bool IsEnoughCurrency(PlayerData playerData, ICostOperation[] costs)
        {
            foreach (var costData in costs)
            {
                if (!costData.CanAfford(playerData))
                {
                    return false;
                }
            }
            return true;
        }

        private static void SpendCurrency(PlayerData playerData, ICostOperation[] costs)
        {
            foreach (var costData in costs)
            {
                costData.Subtract(playerData);
            }
        }

        private static void ApplyRewards(PlayerData playerData, IRewardOperation[] rewards)
        {
            foreach (var costData in rewards)
            {
                costData.Apply(playerData);
            }
        }
    }
}
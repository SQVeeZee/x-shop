using System;
using System.Threading.Tasks;
using Shop.Core;
using UnityEngine;

namespace Shop
{
    public class PurchaseService : MonoBehaviour
    {
        public static PurchaseService Instance { get; private set; }

        public event Action OnPurchased;

        public void Initialize() => Instance = this;

        public bool TryApplyTransaction(PlayerData playerData, ProductConfig productConfig)
        {
            var costs = productConfig.GetCosts();
            if(!IsEnoughCurrency(playerData, costs))
            {
                return false;
            }
            var rewards = productConfig.GetRewards();
            ApplyTransaction(playerData, costs, rewards);
            return true;
        }

        private void ApplyTransaction(PlayerData playerData, ICostOperation[] costs, IRewardOperation[] rewards)
        {
            Subtract(playerData, costs);
            ApplyRewards(playerData, rewards);
            OnPurchased?.Invoke();
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

        private static void Subtract(PlayerData playerData, ICostOperation[] costs)
        {
            foreach (var costData in costs)
            {
                costData.Subtract(playerData);
            }
        }

        public void ApplyRewards(PlayerData playerData, IRewardOperation[] rewards)
        {
            foreach (var costData in rewards)
            {
                costData.Apply(playerData);
            }
        }

        private async Task<bool> BuyAsync(ProductConfig p)
        {
            await Task.Delay(3000);

            return true;
        }
    }
}

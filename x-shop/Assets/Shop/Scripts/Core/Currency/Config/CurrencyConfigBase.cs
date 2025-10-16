using UnityEngine;

namespace Shop.Core
{
    public abstract class CurrencyConfigBase : ScriptableObject, ICostOperation, IRewardOperation
    {
        protected abstract string CurrencyId { get; }
        public abstract string Currency { get; }

        bool ICostOperation.CanAfford(PlayerData playerData) => IsEnoughCurrency(playerData);
        void ICostOperation.Subtract(PlayerData playerData) => SubtractCurrency(playerData);
        void IRewardOperation.Apply(PlayerData playerData) => ApplyReward(playerData);
        public abstract string GetValue(PlayerData playerData);

        protected abstract bool IsEnoughCurrency(PlayerData playerData);
        protected abstract void SubtractCurrency(PlayerData playerData);
        protected abstract void ApplyReward(PlayerData playerData);
    }
}
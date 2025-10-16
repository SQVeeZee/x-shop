using UnityEngine;

namespace Shop.Core
{
    public abstract class CurrencyConfigBase : ScriptableObject, ICostOperation, IRewardOperation, ICurrencyInfo
    {
        protected abstract string CurrencyId { get; }
        public abstract string DescriptionInfo { get; }

        bool ICostOperation.CanAfford(PlayerData playerData) => IsEnoughCurrency(playerData);
        void ICostOperation.Subtract(PlayerData playerData) => SubtractCurrency(playerData);
        void IRewardOperation.Apply(PlayerData playerData) => ApplyReward(playerData);
        string ICurrencyInfo.GetValue(PlayerData playerData) => GetValue(playerData);
        string ICurrencyInfo.Currency => DescriptionInfo;

        protected abstract bool IsEnoughCurrency(PlayerData playerData);
        protected abstract void SubtractCurrency(PlayerData playerData);
        protected abstract void ApplyReward(PlayerData playerData);
        protected abstract string GetValue(PlayerData playerData);
    }
}
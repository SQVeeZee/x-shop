using Shop.Core;
using UnityEngine;

namespace Shop.Gold
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Gold", fileName = "gold_currency", order = 0)]
    public class GoldCurrencyConfig : CurrencyDataConfig
    {
        [SerializeField]
        private int _value;

        protected override string CurrencyId => "gold_currency";
        public override string DescriptionInfo => "Gold";

        protected override bool IsEnoughCurrency(PlayerData playerData)
        {
            var currentCurrency = playerData.GetDataInt(CurrencyId);
            var remainingValue = currentCurrency - _value;
            return remainingValue >= 0;
        }

        protected override void SubtractCurrency(PlayerData playerData)
        {
            var currentCurrency = playerData.GetDataInt(CurrencyId);
            var remainingValue = currentCurrency - _value;
            playerData.SetDataInt(CurrencyId, remainingValue);
        }

        protected override void ApplyReward(PlayerData playerData)
        {
            var current = playerData.GetDataInt(CurrencyId);
            playerData.SetDataInt(CurrencyId, current + _value);
        }
    }
}
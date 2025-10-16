using Shop.Core;
using UnityEngine;

namespace Shop.Gold
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Gold", fileName = "gold_currency", order = 0)]
    public class GoldCurrencyConfig : CurrencyConfigBase
    {
        [SerializeField]
        private int _value;

        protected override string CurrencyId => "gold_currency";
        public override string Currency => "Gold";
        public override string GetValue(PlayerData playerData) => playerData.GetDataInt(CurrencyId).ToString();

        protected override bool IsEnoughCurrency(PlayerData playerData)
        {
            var current = playerData.GetDataInt(CurrencyId);
            var remain = current - _value;
            return remain >= 0;
        }

        protected override void SubtractCurrency(PlayerData playerData)
        {
            var current = playerData.GetDataInt(CurrencyId);
            var remain = current - _value;
            playerData.SetDataInt(CurrencyId, remain);
        }

        protected override void ApplyReward(PlayerData playerData)
        {
            var current = playerData.GetDataInt(CurrencyId);
            var total = current + _value;
            playerData.SetDataInt(CurrencyId, total);
        }

    }
}
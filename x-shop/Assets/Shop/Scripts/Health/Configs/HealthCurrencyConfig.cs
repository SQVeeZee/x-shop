using Shop.Core;
using UnityEngine;

namespace Shop.Health
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Health/Health", fileName = "health_currency", order = 0)]
    public class HealthCurrencyConfig : BaseHealthCurrencyConfig
    {
        [SerializeField]
        private int _value;

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
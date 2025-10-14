using Shop.Core;
using UnityEngine;

namespace Shop.Health
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Health/Health percent", fileName = "health_percent_currency", order = 0)]
    public class HealthCurrencyPercentConfig : BaseHealthCurrencyConfig
    {
        [Range(0f, 100f)]
        [SerializeField]
        private int _percent;

        protected override bool IsEnoughCurrency(PlayerData playerData)
        {
            var current = playerData.GetDataInt(CurrencyId);
            return current > 0;
        }

        protected override void SubtractCurrency(PlayerData playerData)
        {
            var current = playerData.GetDataInt(CurrencyId);
            var delta = Mathf.CeilToInt(current * (_percent / 100f));
            var remain = current - delta;
            playerData.SetDataInt(CurrencyId, remain);
        }

        protected override void ApplyReward(PlayerData playerData)
        {
            var current = playerData.GetDataInt(CurrencyId);
            var delta = Mathf.CeilToInt(current * (_percent / 100f));
            var total = current + delta;
            playerData.SetDataInt(CurrencyId, total);
        }
    }
}
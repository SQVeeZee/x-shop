using System;
using Shop.Core;
using UnityEngine;

namespace Shop.Vip
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Vip", fileName = "vip_currency", order = 0)]
    public sealed class VipCurrencyConfig : BaseCurrencyConfig
    {
        [SerializeField]
        private VipData _vipData;

        protected override string CurrencyId => "vip_currency";
        public override string DescriptionInfo => "Vip";

        protected override bool IsEnoughCurrency(PlayerData playerData)
        {
            var data = GetValue(playerData);
            var current = TimeSpan.Parse(data);
            var delta = _vipData.ToTimeSpan();
            return current >= delta;
        }

        protected override void SubtractCurrency(PlayerData playerData)
        {
            var data = GetValue(playerData);
            var current = TimeSpan.Parse(data);
            var delta = _vipData.ToTimeSpan();
            var remain = current - delta;
            playerData.SetDataString(CurrencyId, remain.ToString());
        }

        protected override void ApplyReward(PlayerData playerData)
        {
            var data = GetValue(playerData);
            var current = TimeSpan.Parse(data);
            var delta = _vipData.ToTimeSpan();
            var total = current + delta;
            playerData.SetDataString(CurrencyId, total.ToString());
        }

        protected override string GetValue(PlayerData playerData)
        {
            var raw = playerData.GetDataString(CurrencyId);

            if (string.IsNullOrEmpty(raw) || !TimeSpan.TryParse(raw, out var ts))
            {
                return "00:00:00";
            }

            return ts.ToString(@"dd\.hh\:mm\:ss");
        }
    }
}
using System;
using Shop.Core;
using UnityEngine;

namespace Shop.Vip
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Vip", fileName = "vip_currency", order = 0)]
    public sealed class VipCurrencyConfig : CurrencyDataConfig
    {
        [SerializeField]
        private VipData _vipData;

        protected override string CurrencyId => "vip_currency";
        public override string DescriptionInfo => "Vip";

        protected override bool IsEnoughCurrency(PlayerData playerData)
        {
            var data = playerData.GetDataString(CurrencyId);
            var current = TimeSpan.Parse(data);
            var delta = _vipData.ToTimeSpan();
            return current >= delta;
        }

        protected override void SubtractCurrency(PlayerData playerData)
        {
            var data = playerData.GetDataString(CurrencyId);
            var current = TimeSpan.Parse(data);
            var delta = _vipData.ToTimeSpan();
            var remain = current - delta;
            playerData.SetDataString(CurrencyId, remain.ToString());
        }

        protected override void ApplyReward(PlayerData playerData)
        {
            var data = playerData.GetDataString(CurrencyId);
            var current = TimeSpan.Parse(data);
            var delta = _vipData.ToTimeSpan();
            var total = current + delta;
            playerData.SetDataString(CurrencyId, total.ToString());
        }
    }
}
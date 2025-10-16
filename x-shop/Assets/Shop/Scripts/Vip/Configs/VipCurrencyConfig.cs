using System;
using System.Globalization;
using Shop.Core;
using UnityEngine;

namespace Shop.Vip
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Vip", fileName = "vip_currency", order = 0)]
    public sealed class VipCurrencyConfig : CurrencyConfigBase
    {
        [SerializeField]
        private VipData _vipData;

        protected override string CurrencyId => "vip_currency";
        public override string Currency => "Vip";

        public override string GetValue(PlayerData playerData)
        {
            var current = GetCurrentTimeSpan(playerData);
            return current.TotalSeconds.ToString(CultureInfo.InvariantCulture);
        }

        protected override bool IsEnoughCurrency(PlayerData playerData)
        {
            var current = GetCurrentTimeSpan(playerData);
            var cost = _vipData.ToTimeSpan();
            return current >= cost;
        }

        protected override void SubtractCurrency(PlayerData playerData)
        {
            var current = GetCurrentTimeSpan(playerData);
            var cost = _vipData.ToTimeSpan();
            var remain = current.Subtract(cost);
            SaveCurrentData(playerData, remain);
        }

        protected override void ApplyReward(PlayerData playerData)
        {
            var current = GetCurrentTimeSpan(playerData);
            var reward = _vipData.ToTimeSpan();
            var total = AddReward(current, reward);
            SaveCurrentData(playerData, total);
        }

        private static TimeSpan AddReward(TimeSpan current, TimeSpan reward)
        {
            var totalTicks = current.Ticks + reward.Ticks;
            if (totalTicks > TimeSpan.MaxValue.Ticks)
            {
                totalTicks = TimeSpan.MaxValue.Ticks;
            }

            return new TimeSpan(totalTicks);
        }

        private void SaveCurrentData(PlayerData playerData, TimeSpan timeSpan)
            => playerData.SetDataString(CurrencyId, timeSpan.ToString("c", CultureInfo.InvariantCulture));

        private TimeSpan GetCurrentTimeSpan(PlayerData playerData)
        {
            var current = playerData.GetDataString(CurrencyId);
            if (string.IsNullOrEmpty(current) || !TimeSpan.TryParse(current, out var currentTimeSpan))
            {
                return TimeSpan.Zero;
            }

            if (currentTimeSpan > TimeSpan.MaxValue)
            {
                currentTimeSpan = TimeSpan.MaxValue;
            }
            return currentTimeSpan;
        }
    }
}
using System;
using System.Globalization;
using UnityEngine;

namespace Shop.Vip
{
    [Serializable]
    public struct VipData
    {
        [SerializeField] private int _days;
        [SerializeField] private int _hours;
        [SerializeField] private int _minutes;
        [SerializeField] private int _seconds;

        public TimeSpan ToTimeSpan()
        {
            var days = Mathf.Max(0, _days);
            var hours = Mathf.Max(0, _hours);
            var minutes = Mathf.Max(0, _minutes);
            var seconds = Mathf.Max(0, _seconds);
            return new TimeSpan(days, hours, minutes, seconds);
        }

        public override string ToString() => ToTimeSpan().ToString("c", CultureInfo.InvariantCulture);
    }
}
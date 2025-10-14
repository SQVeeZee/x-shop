using Shop.Core;
using UnityEngine;

namespace Shop.Location
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Location", fileName = "location_currency", order = 0)]
    public class LocationCurrencyConfig : BaseCurrencyConfig
    {
        [SerializeField]
        private string _value;

        protected override string CurrencyId => $"location_currency";
        public override string DescriptionInfo => "Location";

        protected override bool IsEnoughCurrency(PlayerData playerData)
        {
            var data = playerData.GetDataString(CurrencyId);
            var isExist = data == _value;
            return isExist;
        }

        protected override void SubtractCurrency(PlayerData playerData) => playerData.SetDataString(CurrencyId, string.Empty);
        protected override void ApplyReward(PlayerData playerData) => playerData.SetDataString(CurrencyId, _value);
        protected override string GetValue(PlayerData playerData) => playerData.GetDataString(CurrencyId);
    }
}
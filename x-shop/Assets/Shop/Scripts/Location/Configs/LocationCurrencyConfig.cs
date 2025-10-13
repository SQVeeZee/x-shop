using Shop.Core;
using UnityEngine;

namespace Shop.Location
{
    [CreateAssetMenu(menuName = "Shop/Config/Currency/Location", fileName = "location_currency", order = 0)]
    public class LocationCurrencyConfig : CurrencyDataConfig
    {
        [SerializeField]
        private string _value;

        protected override string CurrencyId => $"location_{_value}";
        public override string DescriptionInfo => "Location";

        protected override bool IsEnoughCurrency(PlayerData playerData) => playerData.GetDataInt(CurrencyId) == 1;
        protected override void SubtractCurrency(PlayerData playerData) => playerData.SetDataInt(CurrencyId, 0);
        protected override void ApplyReward(PlayerData playerData) => playerData.SetDataInt(CurrencyId, 1);
    }
}
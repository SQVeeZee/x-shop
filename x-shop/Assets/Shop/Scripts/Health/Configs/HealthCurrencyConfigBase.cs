using Shop.Core;

namespace Shop.Health
{
    public abstract class HealthCurrencyConfigBase : CurrencyConfigBase
    {
        protected override string CurrencyId => "health_currency";
        public override string DescriptionInfo => "Health";

        protected override string GetValue(PlayerData playerData) => playerData.GetDataInt(CurrencyId).ToString();
    }
}
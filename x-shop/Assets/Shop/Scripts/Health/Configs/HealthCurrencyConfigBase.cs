using Shop.Core;

namespace Shop.Health
{
    public abstract class HealthCurrencyConfigBase : CurrencyConfigBase
    {
        protected override string CurrencyId => "health_currency";
        public override string Currency => "Health";

        public override string GetValue(PlayerData playerData) => playerData.GetDataInt(CurrencyId).ToString();
    }
}
using Shop.Core;

namespace Shop.Health
{
    public abstract class BaseHealthCurrencyConfig : CurrencyDataConfig
    {
        protected override string CurrencyId => "health_currency";
        public override string DescriptionInfo => "Health";
    }
}
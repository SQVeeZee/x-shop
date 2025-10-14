namespace Shop.Core
{
    public interface ICurrencyInfo
    {
        string GetValue(PlayerData playerData);
        string Currency { get; }
    }
}
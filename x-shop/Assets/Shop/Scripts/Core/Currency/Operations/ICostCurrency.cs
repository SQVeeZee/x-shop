namespace Shop.Core
{
    public interface ICostOperation
    {
        bool CanAfford(PlayerData playerData);
        void Subtract(PlayerData playerData);
    }
}
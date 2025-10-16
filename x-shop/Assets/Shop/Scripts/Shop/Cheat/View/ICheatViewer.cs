namespace Shop.Core
{
    public interface ICheatViewer
    {
        void SetCurrency(string id, string value);
        void UpdateCurrency(string value);
    }
}
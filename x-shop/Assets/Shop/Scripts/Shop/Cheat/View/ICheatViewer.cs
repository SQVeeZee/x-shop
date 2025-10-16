namespace Shop
{
    public interface ICheatViewer : ICheatBehaviour
    {
        void SetCurrency(string id, string value);
        void UpdateCurrency(string value);
    }
}
namespace Shop
{
    public interface IInteractable : ICardBehaviour
    {
        void SetState(bool state);
    }
}
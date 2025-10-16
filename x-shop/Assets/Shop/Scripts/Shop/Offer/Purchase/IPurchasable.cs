using System;

namespace Shop
{
    public interface IPurchasable : ICardBehaviour
    {
        void Initialize(Action onPurchase);
        void SetProgressState(BuyingState state);
        void Release();
    }
}
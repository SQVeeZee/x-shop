using System;

namespace Shop
{
    public interface IPurchasable
    {
        void Initialize(Action onPurchase);
        void SetProgressState(BuyingState state);
        void Release();
    }
}
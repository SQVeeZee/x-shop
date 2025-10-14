using System;

namespace Shop
{
    public interface IPurchaseListener
    {
        void Initialize(Action onPurchase);
        void Release();
    }
}
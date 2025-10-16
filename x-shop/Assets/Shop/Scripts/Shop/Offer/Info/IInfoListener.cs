using System;

namespace Shop
{
    public interface IInfoListener
    {
        void Initialize(Action onRequest);
        void Release();
    }
}
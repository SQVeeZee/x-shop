using System;

namespace Shop
{
    public interface IInformational : ICardBehaviour
    {
        void Initialize(Action onRequest);
        void Release();
    }
}
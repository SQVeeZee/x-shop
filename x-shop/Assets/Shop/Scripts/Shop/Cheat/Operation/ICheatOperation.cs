using System;

namespace Shop
{
    public interface ICheatOperation : ICheatBehaviour
    {
        void Initialize(Action callback);
        void Release();
    }
}
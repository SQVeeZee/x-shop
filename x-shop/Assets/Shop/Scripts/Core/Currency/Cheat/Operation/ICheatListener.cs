using System;

namespace Shop.Core
{
    public interface ICheatListener
    {
        void Subscribe(Action callback);
        void Release();
    }
}
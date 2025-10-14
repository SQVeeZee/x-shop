using System;
using UnityEngine;

namespace Shop
{
    public class ViewersService : MonoBehaviour
    {
        public static ViewersService Instance { get; private set; }
        public event Action OnUpdate;

        public void Initialize()
        {
            Instance = this;
        }

        public void NotifyUpdate() => OnUpdate?.Invoke();
    }
}
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Shop
{
    public class InfoRequestHandler
    {
        private readonly SceneService _sceneService;
        private readonly Dictionary<IInfoListener, Action> _bindings;

        [UsedImplicitly]
        public InfoRequestHandler(int amount)
        {
            _sceneService = SceneService.Instance;
            _bindings = new Dictionary<IInfoListener, Action>(amount);
        }

        public void AddRequestListener(InfoData data)
        {
            if (_bindings.ContainsKey(data.Listener))
            {
                return;
            }

            data.Listener.Initialize(handler);
            _bindings.Add(data.Listener, handler);
            return;

            void handler() => _sceneService.LoadScene();
        }

        public void Release()
        {
            foreach (var binding in _bindings)
            {
                binding.Key.Release();
            }
            _bindings.Clear();
        }
    }
}
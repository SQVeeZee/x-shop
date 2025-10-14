using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Shop.Core;

namespace Shop
{
    public sealed class CheatOperationHandler
    {
        private readonly PlayerData _playerData;
        private readonly ViewersService _viewersService;
        private readonly Dictionary<ICheatListener, Action> _bindings;

        [UsedImplicitly]
        public CheatOperationHandler(int amount)
        {
            _bindings = new Dictionary<ICheatListener, Action>(amount);
            _playerData = PlayerData.Instance;
            _viewersService = ViewersService.Instance;
        }

        public void AddCheatListener(CheatData cheatData)
        {
            if (_bindings.ContainsKey(cheatData.CheatListener))
            {
                return;
            }

            var cheatListener = cheatData.CheatListener;
            cheatListener.Subscribe(handler);
            _bindings.Add(cheatData.CheatListener, handler);
            return;

            void handler()
            {
                cheatData.RewardOperation?.Apply(_playerData);
                _viewersService.NotifyUpdate();
            }
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
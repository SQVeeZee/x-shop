using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Shop.Core;

namespace Shop
{
    public class PurchaseProductHandler
    {
        private readonly PlayerData _playerData;
        private readonly PurchaseService _purchaseService;

        private readonly Dictionary<IPurchaseListener, Action> _bindings;

        [UsedImplicitly]
        public PurchaseProductHandler(int amount)
        {
            _playerData = PlayerData.Instance;
            _purchaseService = PurchaseService.Instance;
            _bindings = new Dictionary<IPurchaseListener, Action>(amount);
        }

        public void AddPurchaseListener(PurchaseData purchaseData)
        {
            if (_bindings.ContainsKey(purchaseData.PurchaseListener))
            {
                return;
            }

            purchaseData.PurchaseListener.Initialize(handler);
            _bindings.Add(purchaseData.PurchaseListener, handler);
            return;

            void handler() => CardBuyClickHandler(purchaseData.ProductConfig);
        }

        public void Release()
        {
            foreach (var binding in _bindings)
            {
                binding.Key.Release();
            }
            _bindings.Clear();
        }

        private void CardBuyClickHandler(ProductConfig productConfig)
            => _purchaseService.TryApplyTransaction(_playerData, productConfig);
    }
}
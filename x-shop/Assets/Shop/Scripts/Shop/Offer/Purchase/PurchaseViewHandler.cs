using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Shop.Core;

namespace Shop
{
    public class PurchasableViewHandler
    {
        private readonly PlayerData _playerData;
        private readonly PurchaseService _purchaseService;

        private readonly Dictionary<IPurchasable, Action> _bindings;

        [UsedImplicitly]
        public PurchasableViewHandler(int amount)
        {
            _playerData = PlayerData.Instance;
            _purchaseService = PurchaseService.Instance;
            _bindings = new Dictionary<IPurchasable, Action>(amount);
        }

        ~PurchasableViewHandler()
        {
            foreach (var binding in _bindings)
            {
                binding.Key.Release();
            }
            _bindings.Clear();
        }

        public void AddPurchaseListener(PurchaseData purchaseData)
        {
            var purchasable = purchaseData.Purchasable;
            if (_bindings.ContainsKey(purchasable))
            {
                return;
            }

            purchasable.Initialize(handler);
            _bindings.Add(purchasable, handler);
            return;

            void handler() => CardBuyClickHandler(purchaseData);
        }

        private void CardBuyClickHandler(PurchaseData purchaseData)
        {
            if (_purchaseService.InProgress)
            {
                return;
            }
            purchaseData.Purchasable.SetProgressState(BuyingState.Processing);
            _purchaseService.TryApplyTransaction(_playerData, purchaseData.ProductConfig, resetState);
            return;

            void resetState() => purchaseData.Purchasable.SetProgressState(BuyingState.Ready);
        }
    }
}
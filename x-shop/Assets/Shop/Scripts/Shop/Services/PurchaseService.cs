using System;
using System.Collections;
using Shop.Core;
using UnityEngine;

namespace Shop
{
    public class PurchaseService : MonoBehaviour
    {
        private Coroutine _purchaseCoroutine;
        public static PurchaseService Instance { get; private set; }

        public bool InProgress { get; private set; }

        public event Action OnPurchased;

        public void Initialize() => Instance = this;
        public void Release()
        {
            Instance = null;
            OnPurchased = null;
        }

        public void TryApplyTransactionWithDelay(PlayerData playerData, ProductConfig product, Action callback)
        {
            if (InProgress)
            {
                throw new InvalidOperationException("Purchase in progress");
            }
            TryStopPurchasingCoroutine();
            _purchaseCoroutine = StartCoroutine(ProcessPurchaseRoutine(playerData, product, callback));
        }

        public void TryApplyTransaction(PlayerData playerData, ProductConfig product, Action callback = null)
        {
            if (InProgress)
            {
                throw new InvalidOperationException("Purchase in progress");
            }
            InProgress = true;
            ApplyTransaction(playerData, product);
            InProgress = false;
            callback?.Invoke();
        }

        private IEnumerator ProcessPurchaseRoutine(PlayerData playerData, ProductConfig product, Action callback)
        {
            InProgress = true;
            yield return new WaitForSeconds(3f);
            ApplyTransaction(playerData, product);
            InProgress = false;
            callback?.Invoke();
        }

        private void ApplyTransaction(PlayerData playerData, ProductConfig product)
        {
            var costs = product.GetCostsOperations();
            var rewards = product.GetRewardsOperations();
            ApplyTransaction(playerData, costs, rewards);
        }

        private void ApplyTransaction(PlayerData playerData, ICostOperation[] costs, IRewardOperation[] rewards)
        {
            Subtract(playerData, costs);
            ApplyRewards(playerData, rewards);
            OnPurchased?.Invoke();
        }

        private static void Subtract(PlayerData playerData, ICostOperation[] costs)
        {
            foreach (var costData in costs)
            {
                costData.Subtract(playerData);
            }
        }

        private static void ApplyRewards(PlayerData playerData, IRewardOperation[] rewards)
        {
            foreach (var costData in rewards)
            {
                costData.Apply(playerData);
            }
        }

        private void TryStopPurchasingCoroutine()
        {
            if (_purchaseCoroutine == null)
            {
                return;
            }
            StopCoroutine(_purchaseCoroutine);
            _purchaseCoroutine = null;
        }
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopCard : MonoBehaviour, IPurchasable, IInformational, IInteractable
    {
        [SerializeField]
        private TextMeshProUGUI _header;
        [SerializeField]
        private Button _infoButton;

        [Header("purchase")]
        [SerializeField]
        private Button _purchaseButton;
        [SerializeField]
        private TextMeshProUGUI _purchaseInfo;
        [SerializeField]
        private string _readyToBuyDescription;
        [SerializeField]
        private string _processingDescription;

        private Action _onInfoRequest;
        private Action _onPurchaseRequest;

        public void Initialize(string description) => _header.text = description;

        void IPurchasable.Initialize(Action onRequest)
        {
            _purchaseInfo.text = _readyToBuyDescription;
            _onPurchaseRequest = onRequest;
            _purchaseButton.onClick.AddListener(PurchaseClickHandler);
        }

        void IPurchasable.SetProgressState(BuyingState state)
        {
            var text = (state) switch
            {
                BuyingState.Ready => _readyToBuyDescription,
                BuyingState.Processing => _processingDescription,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
            _purchaseInfo.text = text;
        }

        void IPurchasable.Release()
        {
            _purchaseButton.onClick.RemoveListener(PurchaseClickHandler);
            _onPurchaseRequest = null;
        }

        void IInformational.Initialize(Action onRequest)
        {
            _infoButton.gameObject.SetActive(true);
            _onInfoRequest = onRequest;
            _infoButton.onClick.AddListener(InfoClickHandler);
        }

        void IInformational.Release()
        {
            _infoButton.onClick.RemoveListener(InfoClickHandler);
            _onInfoRequest = null;
        }

        void IInteractable.SetState(bool state) => _purchaseButton.interactable = state;

        private void PurchaseClickHandler() => _onPurchaseRequest?.Invoke();
        private void InfoClickHandler() => _onInfoRequest?.Invoke();
    }
}

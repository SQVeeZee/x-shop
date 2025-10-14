using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopCard : MonoBehaviour, IDescription, IPurchaseListener, IInfoListener, IInteractable
    {
        [SerializeField]
        private TextMeshProUGUI _header;
        [SerializeField]
        private Button _infoButton;
        [SerializeField]
        private Button _buyButton;

        private Action _onInfo;
        private Action _onPurchase;

        void IDescription.SetDescription(string description) => _header.text = description;

        void IPurchaseListener.Initialize(Action onPurchase)
        {
            _onPurchase = onPurchase;
            _buyButton.onClick.AddListener(PurchaseClickHandler);
        }

        void IPurchaseListener.Release()
        {
            _buyButton.onClick.RemoveListener(PurchaseClickHandler);
            _onPurchase = null;
        }

        void IInfoListener.Initialize(Action onRequest)
        {
            _infoButton.gameObject.SetActive(true);
            _onInfo = onRequest;
            _infoButton.onClick.AddListener(InfoClickHandler);
        }

        void IInfoListener.Release()
        {
            _infoButton.onClick.RemoveListener(InfoClickHandler);
            _onInfo = null;
        }

        void IInteractable.SetState(bool state) => _buyButton.interactable = state;

        private void PurchaseClickHandler() => _onPurchase?.Invoke();
        private void InfoClickHandler() => _onInfo?.Invoke();
    }
}

using System;
using Shop.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopCard : MonoBehaviour
    {
        public enum Result
        {
            None = 0,
            Info = 1,
            Buy = 2,
        }

        [SerializeField]
        private TextMeshProUGUI _header;
        [SerializeField]
        private Button _infoButton;
        [SerializeField]
        private Button _buyButton;

        private Action<Result> _callback;

        private void OnDestroy() => UnSubscribes();

        public void Initialize(IProductInfo productInfo, Action<Result> callback)
        {
            _callback = callback;

            ApplyHeader(productInfo.Description);
            Subscribes();
        }

        private void ApplyHeader(string description) => _header.text = description;

        private void Subscribes()
        {
            _infoButton.onClick.AddListener(OnInfoButtonClickHandler);
            _buyButton.onClick.AddListener(OnBuyButtonClickHandler);
        }

        private void UnSubscribes()
        {
            _infoButton.onClick.RemoveListener(OnInfoButtonClickHandler);
            _buyButton.onClick.RemoveListener(OnBuyButtonClickHandler);
        }

        private void OnInfoButtonClickHandler() => _callback?.Invoke(Result.Info);
        private void OnBuyButtonClickHandler() => _callback?.Invoke(Result.Buy);
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopCard : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _header;
        [SerializeField]
        private Button _infoButton;
        [SerializeField]
        private Button _buyButton;
        private ProductConfig _productConfig;

        public void Initialize(ProductConfig productConfig, Action<ProductConfig> buyCallback)
        {
            _productConfig = productConfig;

            AddDescription(productConfig.GetDescription());
            AddBuyClickHandler(buyCallback);
        }

        public void AddInfoClickHandler(Action callback)
        {
            _infoButton.gameObject.SetActive(true);
            _infoButton.onClick.AddListener(() => callback?.Invoke());
        }

        private void AddDescription(string description) => _header.text = description;
        private void AddBuyClickHandler(Action<ProductConfig> callback) => _buyButton.onClick.AddListener(() => callback?.Invoke(_productConfig));

        private void OnDestroy()
        {
            _infoButton.onClick.RemoveAllListeners();
            _buyButton.onClick.RemoveAllListeners();
        }
    }
}

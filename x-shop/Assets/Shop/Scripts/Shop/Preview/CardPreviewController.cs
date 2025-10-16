using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class CardPreviewController : MonoBehaviour
    {
        [SerializeField]
        private Transform _cardRoot;
        [SerializeField]
        private Button _closeButton;

        private SceneService _sceneService;
        private ShopCardService _shopCardService;

        private ProductCardData _previewCardData;

        public void Initialize(ProductConfig productConfig)
        {
            _sceneService = SceneService.Instance;
            _shopCardService = ShopCardService.Instance;

            _closeButton.onClick.AddListener(CloseButtonHandler);
            _previewCardData = CreateShopCard(productConfig);
        }

        public void Release()
        {
            _closeButton.onClick.RemoveListener(CloseButtonHandler);
            ReleaseShopCard(_previewCardData);
        }

        private void CloseButtonHandler() => _sceneService.ReturnBack();

        private ProductCardData CreateShopCard(ProductConfig productConfig)
        {
            var productCardData = _shopCardService.CreateShopProductCard(productConfig, _cardRoot);
            _shopCardService.RegisterPurchase(productCardData);
            _shopCardService.RegisterInteractable(productCardData);
            return productCardData;
        }

        private void ReleaseShopCard(ProductCardData productCardData)
        {
            _shopCardService.UnRegisterPurchase(productCardData);
            _shopCardService.UnRegisterInteractable(productCardData);
        }
    }
}

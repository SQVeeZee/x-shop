using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopOfferController : MonoBehaviour
    {
        [SerializeField]
        private ShopProductsConfig _shopProductsConfig;
        [SerializeField]
        private Transform _cardRoot;

        private ShopCardService _shopCardService;

        private List<ProductCardData> _shopProductCards;

        public void Initialize()
        {
            _shopCardService = ShopCardService.Instance;
            var amount = _shopProductsConfig.Configs.Length + 1;

            _shopCardService.InitializeCardHandlers(amount);
            CreateProductsView(amount);
        }

        public void Release()
        {
            foreach (var shopProductCard in _shopProductCards)
            {
                ReleaseShopCard(shopProductCard);
            }
            _shopProductCards.Clear();
        }

        private void CreateProductsView(int amount)
        {
            _shopProductCards = new List<ProductCardData>(amount);
            foreach (var productConfig in _shopProductsConfig.Configs)
            {
                var productCardData = CreateShopCard(productConfig);
                _shopProductCards.Add(productCardData);
            }
        }

        private ProductCardData CreateShopCard(ProductConfig productConfig)
        {
            var productCardData = _shopCardService.CreateShopProductCard(productConfig, _cardRoot);
            _shopCardService.RegisterInformational(productCardData);
            _shopCardService.RegisterPurchase(productCardData);
            _shopCardService.RegisterInteractable(productCardData);
            return productCardData;
        }

        private void ReleaseShopCard(ProductCardData productCardData)
        {
            _shopCardService.UnRegisterInformational(productCardData);
            _shopCardService.UnRegisterPurchase(productCardData);
            _shopCardService.UnRegisterInteractable(productCardData);
        }
    }
}
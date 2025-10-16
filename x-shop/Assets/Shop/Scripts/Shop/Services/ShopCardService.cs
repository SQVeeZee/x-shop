using UnityEngine;

namespace Shop
{
    public class ShopCardService : MonoBehaviour
    {
        [SerializeField]
        private CardFactory _cardFactory;

        public static ShopCardService Instance { get; private set; }

        private InfoRequestHandler _cardInfoHandler;
        private PurchasableViewHandler _purchaseProductHandler;
        private InteractableHandler _interactableHandler;

        public void Initialize() => Instance = this;

        public void Release()
        {
            Instance = null;

            _cardInfoHandler.Release();
            _purchaseProductHandler.Release();
            _interactableHandler.Release();
        }

        public void InitializeCardHandlers(int amount)
        {
            _cardFactory.Initialize(amount);
            _cardInfoHandler = new InfoRequestHandler(amount);
            _purchaseProductHandler = new PurchasableViewHandler(amount);
            _interactableHandler = new InteractableHandler(amount);
        }

        public ProductCardData CreateShopProductCard(ProductConfig productConfig, Transform root)
        {
            var card = _cardFactory.CreateCard(root);
            var description = productConfig.GetDescription();
            card.Initialize(description);
            return new ProductCardData(productConfig, card);
        }

        public void RegisterPurchase(ProductCardData productCardData) => _purchaseProductHandler.AddProduct(productCardData.Card, productCardData.Config);
        public void UnRegisterPurchase(ProductCardData productCardData) => _purchaseProductHandler.RemoveProduct(productCardData.Card);
        public void RegisterInteractable(ProductCardData productCardData) => _interactableHandler.AddProduct(productCardData.Card, productCardData.Config);
        public void UnRegisterInteractable(ProductCardData productCardData) => _interactableHandler.RemoveProduct(productCardData.Card);
        public void RegisterInformational(ProductCardData productCardData) => _cardInfoHandler.AddProduct(productCardData.Card, productCardData.Config);
        public void UnRegisterInformational(ProductCardData productCardData) => _cardInfoHandler.RemoveProduct(productCardData.Card);
    }
}
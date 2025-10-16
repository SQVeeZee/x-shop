using UnityEngine;

namespace Shop
{
    public class ShopOfferController : MonoBehaviour
    {
        [SerializeField]
        private CardFactory _cardFactory;
        [SerializeField]
        private ShopProductsConfig _shopProductsConfig;

        private DescriptionHandler _descriptionHandler;
        private InfoRequestHandler _cardInfoHandler;
        private PurchasableViewHandler _purchaseProductHandler;
        private InteractableHandler _interactableHandler;

        public void Initialize()
        {
            var amount = _shopProductsConfig.ProductConfigs.Length;
            _descriptionHandler = new DescriptionHandler();
            _cardInfoHandler = new InfoRequestHandler(amount);
            _purchaseProductHandler = new PurchasableViewHandler(amount);
            _interactableHandler = new InteractableHandler(amount);
            _cardFactory.Initialize(amount);
        }

        public void Release() => _cardFactory.Release();

        public void CreateProductsView()
        {
            foreach (var productConfig in _shopProductsConfig.ProductConfigs)
            {
                var card = _cardFactory.CreateCard();
                _purchaseProductHandler.AddPurchaseListener(new PurchaseData(productConfig, card));
                _cardInfoHandler.AddRequestListener(new InfoData(productConfig, card));
                _descriptionHandler.UpdateDescription(new DescriptionData(productConfig, card));
                _interactableHandler.AddInteractable(new InteractableData(productConfig, card));
            }
        }

        public void CheckButtonState() => _interactableHandler.CheckProducts();
    }
}
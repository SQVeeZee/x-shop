using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class CardPreviewController : MonoBehaviour
    {
        [SerializeField]
        private CardFactory _cardFactory;
        [SerializeField]
        private Button _closeButton;

        private DescriptionHandler _descriptionHandler;
        private PurchaseProductHandler _purchaseProductHandler;
        private InteractableHandler _interactableHandler;
        private SceneService _sceneService;

        public void Initialize()
        {
            _sceneService = SceneService.Instance;
            _descriptionHandler = new DescriptionHandler();
            _purchaseProductHandler = new PurchaseProductHandler(1);
            _interactableHandler = new InteractableHandler(1);
            _cardFactory.Initialize(1);
            _closeButton.onClick.AddListener(CloseButtonHandler);
        }

        private void CloseButtonHandler() => _sceneService.ReturnBack();

        public void Release()
        {
            _cardFactory.Release();
            _purchaseProductHandler.Release();
            _closeButton.onClick.RemoveListener(CloseButtonHandler);
        }

        public void CreateProductView(ProductConfig productConfig)
        {
            var card = _cardFactory.CreateCard();
            _purchaseProductHandler.AddPurchaseListener(new PurchaseData(productConfig, card));
            _descriptionHandler.UpdateDescription(new DescriptionData(productConfig, card));
            _interactableHandler.AddInteractable(new InteractableData(productConfig, card));
        }

        public void CheckButtonState() => _interactableHandler.CheckProducts();
    }
}

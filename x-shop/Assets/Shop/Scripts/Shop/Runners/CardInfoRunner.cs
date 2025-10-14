using UnityEngine;

namespace Shop
{
    public class CardInfoRunner : MonoBehaviour
    {
        [SerializeField]
        private CardPreviewController _cardPreviewController;

        private void Start()
        {
            var sceneService = SceneService.Instance;
            var payloadProduct = sceneService.GetPayload<PayloadProduct>();
            _cardPreviewController.Initialize();
            _cardPreviewController.CreateProductView(payloadProduct.InfoData.ProductConfig);
            _cardPreviewController.CheckButtonState();
        }

        private void OnDestroy() => _cardPreviewController.Release();
    }
}

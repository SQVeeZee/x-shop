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
            _cardPreviewController.Initialize(payloadProduct.Config);
        }

        private void OnDestroy() => _cardPreviewController.Release();
    }
}

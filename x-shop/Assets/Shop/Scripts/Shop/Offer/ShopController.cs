using UnityEngine;

namespace Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField]
        private ShopOfferController _offerController;
        [SerializeField]
        private CheatController _cheatController;

        private PurchaseService _purchaseService;
        private ViewersService _viewersService;

        public void Initialize()
        {
            _purchaseService = PurchaseService.Instance;
            _viewersService = ViewersService.Instance;

            _offerController.Initialize();
            _cheatController.Initialize();

            _offerController.CreateProductsView();
            _offerController.CheckButtonState();

            _cheatController.CreateCheats();

            _purchaseService.OnPurchased += PurchaseHandler;
            _viewersService.OnUpdate += UpdateViewersHandler;
        }

        public void Release()
        {
            _purchaseService.OnPurchased -= PurchaseHandler;
            _viewersService.OnUpdate -= UpdateViewersHandler;

            _offerController.Release();
            _cheatController.Release();
        }

        private void PurchaseHandler() => UpdateViewers();
        private void UpdateViewersHandler() => UpdateViewers();

        private void UpdateViewers()
        {
            _offerController.CheckButtonState();
            _cheatController.UpdateCurrencies();
        }
    }
}
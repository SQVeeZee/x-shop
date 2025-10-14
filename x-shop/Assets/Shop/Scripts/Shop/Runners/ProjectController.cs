using Shop.Core;
using UnityEngine;

namespace Shop
{
    public class ProjectRunner : MonoBehaviour
    {
        [Header("services")]
        [SerializeField]
        private PurchaseService _purchaseService;
        [SerializeField]
        private PlayerData _playerData;
        [SerializeField]
        private SceneService _sceneService;
        [SerializeField]
        private ViewersService _viewersService;

        [Header("shop")]
        [SerializeField]
        private CheatController _cheatController;
        [SerializeField]
        private ShopOfferController _offerController;

        public void Awake()
        {
            _purchaseService.Initialize();
            _playerData.Initialize();
            _sceneService.Initialize();
            _viewersService.Initialize();
        }

        private void Start()
        {
            _purchaseService.OnPurchased += PurchaseHandler;
            _viewersService.OnUpdate += UpdateViewersHandler;

            _offerController.Initialize();
            _cheatController.Initialize();

            _offerController.CreateProductsView();
            _offerController.CheckButtonState();

            _cheatController.CreateCheats();
        }

        public void OnDestroy()
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
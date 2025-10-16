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
        private ShopCardService _shopCardService;

        [Header("shop")]
        [SerializeField]
        private ShopController _shopController;

        public void Awake()
        {
            _playerData.Initialize();
            _purchaseService.Initialize();
            _sceneService.Initialize();
            _shopCardService.Initialize();
        }

        private void Start() => _shopController.Initialize();

        public void OnDestroy()
        {
            _playerData.Release();
            _purchaseService.Release();
            _sceneService.Release();
            _shopCardService.Release();

            // _shopController.Release();
        }
    }
}
using Shop.Core;
using UnityEngine;

namespace Shop
{
    public class ShopService : MonoBehaviour
    {
        private PlayerData _playerData;

        [SerializeField]
        private CardFactory _cardFactory;
        [SerializeField]
        private ShopProductsConfig _shopProductsConfig;

        private void Awake() => _playerData = PlayerData.Instance;

        private void Start() => CreateProductsView();

        private void OnDestroy()
        {

        }

        private void CreateProductsView()
        {
            foreach (var productConfig in _shopProductsConfig.ProductConfigs)
            {
                var card = _cardFactory.CreateCard(productConfig, CardBuyClickHandler);
                card.AddInfoButtonClickHandler(CardInfoClickHandler);
            }
        }

        private void CardBuyClickHandler(ProductConfig productConfig)
        {
            var transactionSolver = new TransactionSolver(productConfig);
            TryBuyProduct(transactionSolver);
        }

        private void CardInfoClickHandler() { }

        private void TryBuyProduct(TransactionSolver transactionSolver)
        {
            var isApplied = transactionSolver.TryApplyTransaction(_playerData);
        }
    }
}

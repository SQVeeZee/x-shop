using System;
using UnityEngine;

namespace Shop
{
    public class CardFactory : MonoBehaviour
    {
        [SerializeField]
        private ShopCard _shopCard;
        [SerializeField]
        private Transform _root;

        public ShopCardReference CreateCard(ProductConfig productConfig, Action<ProductConfig> buyCallback)
        {
            var cardInstance = Instantiate(_shopCard, _root);
            cardInstance.Initialize(productConfig, buyCallback);
            return new ShopCardReference(cardInstance);
        }
    }
}
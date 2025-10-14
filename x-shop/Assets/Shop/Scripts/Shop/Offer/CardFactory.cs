using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class CardFactory : MonoBehaviour
    {
        [SerializeField]
        private ShopCard _shopCard;
        [SerializeField]
        private Transform _root;

        private List<ShopCard> _shopCards;

        public void Initialize(int length) => _shopCards = new List<ShopCard>(length);

        public ShopCard CreateCard()
        {
            var cardInstance = Instantiate(_shopCard, _root);
            _shopCards.Add(cardInstance);
            return cardInstance;
        }

        public void Release()
        {
            foreach (var shopCard in _shopCards)
            {
                Destroy(shopCard.gameObject);
            }
            _shopCards.Clear();
        }
    }
}
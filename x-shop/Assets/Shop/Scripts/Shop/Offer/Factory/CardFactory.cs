using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class CardFactory : MonoBehaviour
    {
        [SerializeField]
        private ShopCard _shopCard;

        private List<ShopCard> _shopCards;

        public void Initialize(int length) => _shopCards = new List<ShopCard>(length);

        public ShopCard CreateCard(Transform root)
        {
            var cardInstance = Instantiate(_shopCard, root);
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
using System;

namespace Shop
{
    public readonly struct ShopCardReference
    {
        private readonly ShopCard _shopCard;

        public ShopCardReference(ShopCard shopCard) => _shopCard = shopCard;

        public ShopCardReference AddInfoButtonClickHandler(Action callback)
        {
            _shopCard.AddInfoClickHandler(callback);
            return this;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    public abstract class ShopProductHandler<TBehaviour>
        where TBehaviour : ICardBehaviour
    {
        protected List<HandlerInfo<TBehaviour>> ProductCards { get; }

        protected ShopProductHandler(int amount) => ProductCards = new List<HandlerInfo<TBehaviour>>(amount);

        public void AddProduct(TBehaviour behaviour, ProductConfig productConfig)
        {
            var card = new HandlerInfo<TBehaviour>(behaviour, productConfig);
            ProductCards.Add(card);
            OnAddedProduct(card);
        }

        public void RemoveProduct(TBehaviour productCardData)
        {
            var product = ProductCards.First(x => Equals(x.View, productCardData));
            ProductCards.Remove(product);
            DisposeProduct(product.View);
        }

        public abstract void Release();
        protected virtual void OnAddedProduct(HandlerInfo<TBehaviour> productCardData) { }
        protected virtual void DisposeProduct(TBehaviour productCardData) { }
    }
}
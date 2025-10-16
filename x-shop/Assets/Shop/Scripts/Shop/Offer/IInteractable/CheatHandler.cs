using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    public abstract class CheatHandler<TBehaviour>
        where TBehaviour : ICheatBehaviour
    {
        protected List<HandlerInfo<TBehaviour>> CheatViews { get; }

        protected CheatHandler(int amount) => CheatViews = new List<HandlerInfo<TBehaviour>>(amount);

        public void AddProduct(TBehaviour behaviour, ProductConfig productConfig)
        {
            var card = new HandlerInfo<TBehaviour>(behaviour, productConfig);
            CheatViews.Add(card);
            OnAddedProduct(card);
        }

        public void RemoveProduct(TBehaviour productCardData)
        {
            var product = CheatViews.First(x => Equals(x.View, productCardData));
            CheatViews.Remove(product);
            DisposeProduct(product.View);
        }

        public virtual void Release() { }

        protected virtual void OnAddedProduct(HandlerInfo<TBehaviour> productCardData) { }
        protected virtual void DisposeProduct(TBehaviour productCardData) { }
    }
}
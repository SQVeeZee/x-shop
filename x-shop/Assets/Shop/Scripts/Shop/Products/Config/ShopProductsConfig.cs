using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Shop/Config/Products/Shop products", fileName = "shop_products", order = 0)]
    public class ShopProductsConfig : ScriptableObject
    {
        [SerializeField]
        private ProductConfig[] _productConfigs;

        public ProductConfig[] Configs => _productConfigs;
    }
}
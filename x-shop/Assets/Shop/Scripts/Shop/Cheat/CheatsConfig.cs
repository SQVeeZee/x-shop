using Shop.Core;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Shop/Config/Cheats config", fileName = "cheat_config", order = 0)]
    public class CheatsConfig : ScriptableObject
    {
        [SerializeField]
        private BaseCurrencyConfig[] _configs;

        public BaseCurrencyConfig[] Configs => _configs;
    }
}
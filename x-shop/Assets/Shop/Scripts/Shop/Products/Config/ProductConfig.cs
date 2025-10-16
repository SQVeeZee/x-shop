using System;
using Shop.Core;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Shop/Config/Products/Product", fileName = "product", order = 0)]
    public class ProductConfig : ScriptableObject
    {
        [SerializeField]
        private CurrencyConfigBase[] _cost;
        [SerializeField]
        private CurrencyConfigBase[] _reward;

        public CurrencyConfigBase[] Costs => _cost;
        public CurrencyConfigBase[] Rewards => _reward;

        public ICostOperation[] GetCostsOperations()
        {
            if (_cost == null || _cost.Length == 0)
            {
                return Array.Empty<ICostOperation>();
            }
            var tmp = new ICostOperation[_cost.Length];
            for (var i = 0; i < _cost.Length; i++)
            {
                tmp[i] = _cost[i];
            }
            return tmp;
        }

        public IRewardOperation[] GetRewardsOperations()
        {
            if (_reward == null || _reward.Length == 0)
            {
                return Array.Empty<IRewardOperation>();
            }
            var tmp = new IRewardOperation[_reward.Length];
            for (var i = 0; i < _reward.Length; i++)
            {
                tmp[i] = _reward[i];
            }
            return tmp;
        }

        public string GetDescription()
        {
            if ((_reward == null || _reward.Length == 0) && (_cost == null || _cost.Length == 0))
            {
                return string.Empty;
            }

            var rewardPart = string.Empty;
            var costPart = string.Empty;

            if (_reward is { Length: > 0 })
            {
                for (var i = 0; i < _reward.Length; i++)
                {
                    var reward = _reward[i];
                    if (reward == null)
                    {
                        continue;
                    }
                    rewardPart += reward.Currency;
                    if (i < _reward.Length - 1)
                    {
                        rewardPart += " and ";
                    }
                }
            }

            if (_cost is { Length: > 0 })
            {
                for (var i = 0; i < _cost.Length; i++)
                {
                    var cost = _cost[i];
                    if (cost == null)
                    {
                        continue;
                    }
                    costPart += cost.Currency;
                    if (i < _cost.Length - 1)
                    {
                        costPart += " and ";
                    }
                }
            }

            if (rewardPart.Length == 0)
            {
                return $"Costs {costPart}";
            }
            if (costPart.Length == 0)
            {
                return $"Gives {rewardPart}";
            }

            return $"{rewardPart} for {costPart}";
        }
    }
}
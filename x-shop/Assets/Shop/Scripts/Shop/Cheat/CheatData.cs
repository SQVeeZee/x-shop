using Shop.Core;

namespace Shop
{
    public readonly struct CheatData
    {
        public ICheatListener CheatListener { get; }
        public IRewardOperation RewardOperation { get; }

        public CheatData(ICheatListener cheatListener, IRewardOperation rewardOperation)
        {
            CheatListener = cheatListener;
            RewardOperation = rewardOperation;
        }
    }
}
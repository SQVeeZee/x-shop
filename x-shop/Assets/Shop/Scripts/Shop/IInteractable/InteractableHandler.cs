using System.Collections.Generic;
using Shop.Core;

namespace Shop
{
    public class InteractableHandler
    {
        private readonly List<InteractableData> _interactableData;
        private readonly PlayerData _playerData;

        public InteractableHandler(int amount)
        {
            _playerData = PlayerData.Instance;
            _interactableData = new List<InteractableData>(amount);
        }

        public void AddInteractable(InteractableData interactableData)
        {
            _interactableData.Add(interactableData);
            UpdateInteractableState(interactableData);
        }

        public void CheckProducts()
        {
            foreach (var interactableData in _interactableData)
            {
                UpdateInteractableState(interactableData);
            }
        }

        public void Release() => _interactableData.Clear();

        private void UpdateInteractableState(InteractableData interactableData)
        {
            var costs = interactableData.ProductConfig.GetCosts();
            foreach (var costOperation in costs)
            {
                if (costOperation.CanAfford(_playerData))
                {
                    continue;
                }
                interactableData.Interactable.SetState(false);
                return;
            }
            interactableData.Interactable.SetState(true);
        }


    }
}
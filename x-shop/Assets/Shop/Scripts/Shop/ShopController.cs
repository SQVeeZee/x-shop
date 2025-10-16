using UnityEngine;

namespace Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField]
        private ShopOfferController _offerController;
        [SerializeField]
        private CheatController _cheatController;

        public void Initialize()
        {
            _offerController.Initialize();
            _cheatController.Initialize();
        }

        public void Release()
        {
            _offerController.Release();
            _cheatController.Release();
        }
    }
}
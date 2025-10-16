using UnityEngine;

namespace Shop
{
    public class CheatController : MonoBehaviour
    {
        [SerializeField]
        private ShopProductsConfig _cheatsConfig;
        [SerializeField]
        private CheatFactory _cheatFactory;

        private CheatOperationHandler _cheatOperationHandler;
        private CheatViewHandler _cheatViewerHandler;

        public void Initialize()
        {
            var length = _cheatsConfig.Configs.Length;
            _cheatOperationHandler = new CheatOperationHandler(length);
            _cheatViewerHandler = new CheatViewHandler(length);
            _cheatFactory.Initialize(length);
            CreateCheats();
        }

        public void Release()
        {
            _cheatOperationHandler.Release();
            _cheatViewerHandler.Release();
            _cheatFactory.Release();
        }

        private void CreateCheats()
        {
            foreach (var config in _cheatsConfig.Configs)
            {
                var view = _cheatFactory.CreateCheat();
                _cheatOperationHandler.AddProduct(view, config);
                _cheatViewerHandler.AddProduct(view, config);
            }
        }
    }
}
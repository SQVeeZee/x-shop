using UnityEngine;

namespace Shop
{
    public class CheatController : MonoBehaviour
    {
        [SerializeField]
        private CheatsConfig _cheatsConfig;
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
        }

        public void Release()
        {
            _cheatOperationHandler.Release();
            _cheatFactory.Release();
        }

        public void CreateCheats()
        {
            foreach (var config in _cheatsConfig.Configs)
            {
                var cheatInstance = _cheatFactory.CreateCheat();
                _cheatOperationHandler.AddCheatListener(new CheatData(cheatInstance, config));
                _cheatViewerHandler.AddViewer(new CheatViewData(cheatInstance, config));
            }
        }

        public void UpdateCurrencies() => _cheatViewerHandler.UpdateViewers();
    }
}
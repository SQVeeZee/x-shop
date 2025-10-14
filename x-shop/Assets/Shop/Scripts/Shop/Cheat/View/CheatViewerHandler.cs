using System.Collections.Generic;
using Shop.Core;

namespace Shop
{
    public class CheatViewerHandler
    {
        private readonly List<CheatViewData> _viewDatas;
        private readonly PlayerData _playerData;

        public CheatViewerHandler(int amount)
        {
            _playerData = PlayerData.Instance;
            _viewDatas = new List<CheatViewData>(amount);
        }

        public void AddViewer(CheatViewData viewData)
        {
            _viewDatas.Add(viewData);
            SetViewer(viewData);
        }

        public void UpdateViewers()
        {
            foreach (var viewData in _viewDatas)
            {
                var value = viewData.Info.GetValue(_playerData);
                viewData.Viewer.UpdateCurrency(value);
            }
        }

        private void SetViewer(CheatViewData viewData)
        {
            var info = viewData.Info;
            var id = info.Currency;
            var value = info.GetValue(_playerData);
            viewData.Viewer.SetCurrency(id, value);
        }
    }
}
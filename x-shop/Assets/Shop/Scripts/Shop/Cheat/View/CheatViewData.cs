using Shop.Core;

namespace Shop
{
    public readonly struct CheatViewData
    {
        public ICheatViewer Viewer { get; }
        public ICurrencyInfo Info { get; }

        public CheatViewData(ICheatViewer viewer, ICurrencyInfo info)
        {
            Viewer = viewer;
            Info = info;
        }
    }
}
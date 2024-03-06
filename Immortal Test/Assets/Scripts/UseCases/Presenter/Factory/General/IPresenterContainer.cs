using Immortal.Presenter;

namespace Immortal.PresenterFactory
{
    public interface IPresenterContainer
    {
        ICellDisplays CellDisplays {get; }
        IHideable ActionPanel {get; }
    }
}
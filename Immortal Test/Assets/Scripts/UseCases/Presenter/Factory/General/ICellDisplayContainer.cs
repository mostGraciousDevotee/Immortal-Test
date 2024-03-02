using Immortal.Presenter;

namespace Immortal.PresenterFactory
{
    public interface ICellDisplayContainer
    {
        ICellDisplay AttackDisplayPrefab {get; }
        ICellDisplay MoveDisplayPrefab {get; }
        ICellDisplays CellDisplays {get; }
        IHideable ActionPanel {get; }

        void Init(int cellSize);
    }
}
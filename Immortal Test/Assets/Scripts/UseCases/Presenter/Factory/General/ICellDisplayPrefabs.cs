using Immortal.Presenter;

namespace Immortal.PresenterFactory
{   
    public interface ICellDisplayPrefabs
    {
        ICellDisplay AttackDisplayPrefab {get; }
        ICellDisplay MoveDisplayPrefab {get; }
    }
}
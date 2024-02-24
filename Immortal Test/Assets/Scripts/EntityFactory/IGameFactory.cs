using Immortal.App;
using Immortal.CellSystem;

namespace Immortal.InteractorFactory
{
    public interface IGameFactory
    {
        ISquareCells MakeSquareCells();
        ICellValidator MakeMovementValidator();
        ICellValidator MakeAttackValidator();
        ICommandHistory MakeCommandHistory();
    }
}
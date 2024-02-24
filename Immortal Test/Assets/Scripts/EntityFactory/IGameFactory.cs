using Immortal.App;
using Immortal.CellSystem;

namespace Immortal.InteractorFactory
{
    public interface IGameFactory
    {
        ITurnManager MakeTurnManager();
        ISquareCells MakeSquareCells();
        ICellValidator MakeMovementValidator();
        ICellValidator MakeAttackValidator();
        ICommandHistory MakeCommandHistory();
    }
}
using Immortal.App;
using Immortal.CellSystem;
using Immortal.UnitSystem;

namespace Immortal.EntityFactory
{
    public interface IGameFactory
    {
        ITurnManager MakeTurnManager();
        ISquareCells MakeSquareCells();
        ICellValidator MakeMovementValidator();
        ICellValidator MakeAttackValidator();
        ICommandHistory MakeCommandHistory();
        IUnit MakeAdam();
        IUnit MakeBruce();
    }
}
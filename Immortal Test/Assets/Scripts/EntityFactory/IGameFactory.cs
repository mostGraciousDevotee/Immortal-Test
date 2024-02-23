using Immortal.App;
using Immortal.Entities;

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
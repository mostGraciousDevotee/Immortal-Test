using Immortal.Entities;

namespace Immortal.App
{
    public interface IGameFactory
    {
        ITurnManager MakeTurnManager();
        ISquareCells MakeSquareCells();
        ICellValidator MakeMovementValidator();
        ICommandHistory MakeCommandHistory();
        IUnit MakeAdam();
        IUnit MakeBruce();
    }
}
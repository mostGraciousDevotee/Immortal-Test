using Immortal.Entities;

namespace Immortal.App
{
    public interface IGameFactory
    {
        ITurnManager MakeTurnManager();
        ISquareCells MakeSquareCells();
        IMovementValidator MakeMovementValidator();
        IUnit MakeAdam();
        IUnit MakeBruce();
    }
}
using Immortal.Entities;

namespace Immortal.App
{
    public interface IGameFactory
    {
        ITurnManager MakeTurnManager();
        IUnit MakeAdam();
        IUnit MakeBruce();
    }
}
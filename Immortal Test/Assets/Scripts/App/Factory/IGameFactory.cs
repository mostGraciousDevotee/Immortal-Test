using Immortal.Entities;

namespace Immortal.App
{
    public interface IGameFactory
    {
        ITurnManager TurnManager {get; }
        IUnit Adam {get; }
        IUnit Bruce {get; }
    }
}
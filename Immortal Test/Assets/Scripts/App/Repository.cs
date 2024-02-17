using Immortal.Entities;

namespace Immortal.App
{
    public class Repository : IRepository
    {
        ITurnManager _turnManager;
        IUnit _adam;
        IUnit _bruce;

        public Repository(IGameFactory factory)
        {
            _turnManager = factory.MakeTurnManager();
            _adam = factory.MakeAdam();
            _bruce = factory.MakeBruce();
        }

        public ITurnManager TurnManager => _turnManager;
        public IUnit Adam => _adam;
        public IUnit Bruce => _bruce;
    }

    public interface IRepository
    {
        ITurnManager TurnManager {get; }
        IUnit Adam {get; }
        IUnit Bruce {get; }
    }
}
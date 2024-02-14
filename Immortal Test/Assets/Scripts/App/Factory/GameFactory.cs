using Immortal.Entities;

namespace Immortal.App
{
    public class GameFactory : IGameFactory
    {
        IUnit _adam;
        IUnit _bruce;
        ITurnManager _turnManager;
        
        public GameFactory()
        {
            _adam = MakeAdam();
            _bruce = MakeBruce();
            
            _turnManager = MakeTurnManager();
        }

        IUnit MakeAdam()
        {
            return new Unit("Adam", 10);
        }

        IUnit MakeBruce()
        {
            return new Unit("Bruce", 9);
        }

        ITurnManager MakeTurnManager()
        {
            return new TurnManager();
        }
        
        public ITurnManager TurnManager => _turnManager;
        public IUnit Adam => _adam;
        public IUnit Bruce => _bruce;
    }
}
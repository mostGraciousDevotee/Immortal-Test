using Immortal.Entities;

namespace Immortal.App
{
    public class GameFactory : IFactory
    {
        IUnit _adam;
        IUnit _bruce;
        ITurnManager _turnManager;
        
        public GameFactory()
        {
            _adam = MakeAdam();
            _bruce = MakeBruce();
            
            _turnManager = MakeTurnManager();
            BuildTurnManager();
        }
        
        public ITurnManager GetTurnManager()
        {
            return _turnManager;
        }

        void BuildTurnManager()
        {
            _turnManager.AddUnit(_adam);
            _turnManager.AddUnit(_bruce);
        }
        
        ITurnManager MakeTurnManager()
        {
            return new TurnManager();
        }

        IUnit GetAdam()
        {
            return _adam;
        }

        IUnit MakeAdam()
        {
            return new Unit("Adam", 10);
        }

        IUnit GetBruce()
        {
            return _adam;
        }

        IUnit MakeBruce()
        {
            return new Unit("Bruce", 9);
        }
    }
}
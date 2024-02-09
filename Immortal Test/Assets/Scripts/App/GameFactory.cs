using Immortal.Entities;

namespace Immortal.App
{
    public class GameFactory : IFactory
    {
        IUnit _adam;
        ITurnManager _turnManager;
        
        public GameFactory()
        {
            _adam = MakeAdam();

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
    }
}


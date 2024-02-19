using Immortal.App;
using Immortal.Entities;

namespace Immortal.Factory
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

        public IUnit MakeAdam()
        {
            var name = "Adam";
            var speed = 10;
            var maxMovePoints = 2;

            var moveable = new Moveable(maxMovePoints);
            var adam = new Unit(name, speed);

            adam.AddComponent<IMoveable>(moveable);
            
            return adam;
        }

        public IUnit MakeBruce()
        {
            var name = "Bruce";
            var speed = 9;
            var maxMovePoints = 4;

            var moveable = new Moveable(maxMovePoints);
            var bruce = new Unit(name, speed);

            bruce.AddComponent<IMoveable>(moveable);

            return bruce;
        }

        public ITurnManager MakeTurnManager()
        {
            return new TurnManager();
        }
    }
}
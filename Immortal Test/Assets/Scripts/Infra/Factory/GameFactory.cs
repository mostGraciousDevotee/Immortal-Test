using Immortal.App;
using Immortal.Entities;

namespace Immortal.Factory
{
    public class GameFactory : IGameFactory
    {   
        ITurnManager _turnManager;
        IMovementValidator _movementValidator;
        ISquareCells _squareCells;


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
            if (_turnManager == null)
            {
                _turnManager = new TurnManager();
            }

            return _turnManager;
        }

        public ISquareCells MakeSquareCells()
        {
            var squareDim = 16;
            var cellSize = 2;

            if (_squareCells == null)
            {
                _squareCells = new SquareCells(squareDim, squareDim, cellSize);
            }
            
            return _squareCells;
        }

        public IMovementValidator MakeMovementValidator()
        {
            if (_movementValidator == null)
            {
                _movementValidator = new MovementValidator(MakeSquareCells());
            }
            
            return _movementValidator;
        }
    }
}
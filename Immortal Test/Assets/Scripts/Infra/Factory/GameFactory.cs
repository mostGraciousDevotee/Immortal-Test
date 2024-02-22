using Immortal.App;
using Immortal.Entities;

namespace Immortal.Factory
{
    public class GameFactory : IGameFactory
    {   
        ITurnManager _turnManager;
        ICellValidator _movementValidator;
        ICellValidator _attackValidator;
        ISquareCells _squareCells;
        ICommandHistory _commandHistory;

        public IUnit MakeAdam()
        {
            var name = "Adam";
            var speed = 10;
            var maxMovePoints = 2;
            var attackRange = 1;

            var moveable = new Moveable(maxMovePoints);
            var combatant = new Combatant(attackRange);
            var adam = new Unit(name, speed);

            adam.AddComponent<IMoveable>(moveable);
            adam.AddComponent<ICombatant>(combatant);
            
            return adam;
        }

        public IUnit MakeBruce()
        {
            var name = "Bruce";
            var speed = 9;
            var maxMovePoints = 4;
            var attackRange = 2;

            var moveable = new Moveable(maxMovePoints);
            var combatant = new Combatant(attackRange);
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

        public ICellValidator MakeMovementValidator()
        {
            if (_movementValidator == null)
            {
                _movementValidator = new MovementValidator(MakeSquareCells());
            }
            
            return _movementValidator;
        }

        public ICellValidator MakeAttackValidator()
        {
            if (_attackValidator == null)
            {
                _attackValidator = new AttackValidator(MakeSquareCells());
            }

            return _attackValidator;
        }

        public ICommandHistory MakeCommandHistory()
        {
            if (_commandHistory == null)
            {
                _commandHistory = new CommandHistory();
            }

            return _commandHistory;
        }
    }
}
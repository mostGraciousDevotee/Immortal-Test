using Immortal.CellImplementation;
using Immortal.CellSystem;
using Immortal.InteractorFactory;

namespace Immortal.App
{
    public class GameFactory : IGameFactory
    {   
        ICellValidator _movementValidator;
        ICellValidator _attackValidator;
        ISquareCells _squareCells;
        ICommandHistory _commandHistory;

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
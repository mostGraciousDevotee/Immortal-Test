using Immortal.UnitSystem;
using Immortal.CellSystem;
using Immortal.InteractorFactory;
using Immortal.UnitFactoryPackage;

namespace Immortal.App
{
    public class Repository : IRepository
    {
        ITurnManager _turnManager;

        ISquareCells _squareCells;
        ICellValidator _movementValidator;
        ICellValidator _attackValidator;

        ICommandHistory _commandHistory;

        IUnit _adam;
        IUnit _bruce;

        public Repository(IGameFactory factory, IUnitFactory unitFactory)
        {
            _turnManager = factory.MakeTurnManager();

            _squareCells = factory.MakeSquareCells();
            _movementValidator = factory.MakeMovementValidator();
            _attackValidator = factory.MakeAttackValidator();

            _commandHistory = factory.MakeCommandHistory();

            _adam = unitFactory.MakeAdam();
            _bruce = unitFactory.MakeBruce();
        }

        public ITurnManager TurnManager => _turnManager;
        public ISquareCells SquareCells => _squareCells;
        public ICellValidator MovementValidator => _movementValidator;
        public ICellValidator AttackValidator => _attackValidator;
        public ICommandHistory CommandHistory => _commandHistory;

        public IUnit Adam => _adam;
        public IUnit Bruce => _bruce;
    }

    public interface IRepository
    {
        ITurnManager TurnManager {get; }
        ICellValidator MovementValidator {get; }
        ICellValidator AttackValidator {get; }
        ISquareCells SquareCells {get; }
        ICommandHistory CommandHistory {get; }

        IUnit Adam {get; }
        IUnit Bruce {get; }
    }
}
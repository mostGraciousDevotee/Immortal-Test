using Immortal.Entities;

namespace Immortal.App
{
    public class Repository : IRepository
    {
        ITurnManager _turnManager;
        ISquareCells _squareCells;
        IMovementValidator _movementValidator;

        IUnit _adam;
        IUnit _bruce;

        public Repository(IGameFactory factory)
        {
            _turnManager = factory.MakeTurnManager();
            _squareCells = factory.MakeSquareCells();
            _movementValidator = factory.MakeMovementValidator();

            _adam = factory.MakeAdam();
            _bruce = factory.MakeBruce();
        }

        public ITurnManager TurnManager => _turnManager;
        public ISquareCells SquareCells => _squareCells;
        public IMovementValidator MovementValidator => _movementValidator;

        public IUnit Adam => _adam;
        public IUnit Bruce => _bruce;
    }

    public interface IRepository
    {
        ITurnManager TurnManager {get; }
        IMovementValidator MovementValidator {get; }
        ISquareCells SquareCells {get; }

        IUnit Adam {get; }
        IUnit Bruce {get; }
    }
}
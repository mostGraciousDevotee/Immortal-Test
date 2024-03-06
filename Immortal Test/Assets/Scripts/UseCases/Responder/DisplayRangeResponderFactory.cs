using Immortal.CellSystem;
using Immortal.Responder;
using Immortal.ResponderFactory;
using Immortal.UnitSystem;

namespace Immortal.ResponderImpl
{
    public class DisplayRangeResponderFactory : IDisplayRangeResponderFactory
    {
        ITurnManager _turnManager;
        ISquareCells _squareCells;
        IValidCellProvider _moveCellProvider;
        IValidCellProvider _attackCellProvider;

        IDisplayRangeResponder _moveRangeResponder;
        IDisplayRangeResponder _attackRangeResponder;
        
        public DisplayRangeResponderFactory
        (
            ITurnManager turnManager,
            ISquareCells squareCells,
            IValidCellProvider validMoveCellProvider,
            IValidCellProvider validAttackCellProvider
        )
        {
            _turnManager = turnManager;
            _squareCells = squareCells;
            _moveCellProvider = validMoveCellProvider;
            _attackCellProvider = validAttackCellProvider;
        }
        public IDisplayRangeResponder MakeDisplayAttackResponder()
        {
            if (_attackRangeResponder == null)
            {
                _attackRangeResponder = new DisplayAttackResponder
                (
                    "Attack",
                    _turnManager,
                    _squareCells,
                    _attackCellProvider
                );
            }

            return _attackRangeResponder;
        }

        public IDisplayRangeResponder MakeDisplayMoveResponder()
        {
            if (_moveRangeResponder == null)
            {
                _moveRangeResponder = new DisplayMovementResponder
                (
                    "Movement",
                    _turnManager,
                    _squareCells,
                    _moveCellProvider
                );
            }
            
            return _moveRangeResponder;
        }
    }
}

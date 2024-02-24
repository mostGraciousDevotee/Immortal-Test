using Immortal.UnitSystem;

namespace Immortal.Test
{
    public class MovementValidatorTest : CellValidatorTest
    {   
        protected override void GetRange()
        {
            _range = _adam.GetComponent<IMoveable>().CurrentMovePoints;
        }

        protected override void GetValidCells()
        {
            var startPos = _adam.Position;
            _validCells = _gameFactory.MakeMovementValidator().GetValidCells(_adam.Position, _range);
        }

        protected override bool IsValid()
        {
            var notContainingAdam = Assert.AreEqual<bool>
            (
                false,
                _validCells.Contains(_adam.Position),
                "Valid cells containing Adam position"
            );

            var notContainingBruce = Assert.AreEqual<bool>
            (
                false,
                _validCells.Contains(_bruce.Position),
                "Valid cells containing Bruce position"
            );

            return notContainingAdam && notContainingBruce;
        }
    }
}
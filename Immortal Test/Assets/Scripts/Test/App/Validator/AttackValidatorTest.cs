using Immortal.UnitSystem;

namespace Immortal.Test
{
    public class AttackValidatorTest : CellValidatorTest
    {
        protected override void GetRange()
        {
            _range = _adam.GetComponent<ICombatant>().AttackRange;
        }

        protected override void GetValidCells()
        {
            var startPos = _adam.Position;
            _validCells = _cellFactory.GetValidAttackProvider().GetValidCells(_adam.Position, _range);
        }

        protected override bool IsValid()
        {
            var containingBruce = Assert.AreEqual<bool>
            (
                true,
                _validCells.Contains(_bruce.Position),
                "Valid cells not containing Bruce position"
            );

            return containingBruce;
        }
    }
}
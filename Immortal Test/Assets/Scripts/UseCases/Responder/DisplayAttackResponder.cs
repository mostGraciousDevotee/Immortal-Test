using System;
using Immortal.CellSystem;
using Immortal.UnitSystem;

namespace Immortal.ResponderImpl
{
    public class DisplayAttackResponder : DisplayRangeResponder
    {
        public DisplayAttackResponder
        (
            string displayType,
            ITurnManager turnManager,
            ISquareCells squareCells,
            IValidCellProvider cellProvider
        ) : base(displayType, turnManager, squareCells, cellProvider)
        {
        }

        protected override int GetRange(IUnit currentUnit)
        {
            var combatant = currentUnit.GetComponent<ICombatant>();

            if (combatant == null)
            {
                throw new Exception("Failed to fetch combatant on DisplayAttack command");
            }

            return combatant.AttackRange;
        }
    }
}
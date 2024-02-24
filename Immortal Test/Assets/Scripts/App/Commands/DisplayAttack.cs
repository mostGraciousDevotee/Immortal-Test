using System;
using Immortal.UnitSystem;

namespace Immortal.App
{
    public class DisplayAttack : DisplayRange
    {
        public DisplayAttack
        (
            ITurnManager turnManager,
            ICommandHistory commandHistory,
            ICellValidator cellValidator,
            ICellDisplays cellDisplays,
            ICellDisplay cellDisplayPrefab,
            IHideable actionPanel) :
            base
            (
                turnManager,
                commandHistory,
                cellValidator,
                cellDisplays,
                cellDisplayPrefab,
                actionPanel
            )
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
using System;
using Immortal.UnitSystem;
using Immortal.CellSystem;
using Immortal.Presenter;
using Immortal.Command;

namespace Immortal.CommandImplementation
{
    public class DisplayAttack : DisplayRange
    {
        public DisplayAttack
        (
            ITurnManager turnManager,
            ICommandHistory commandHistory,
            IValidCellProvider validAttackProvider,
            ICellDisplays cellDisplays,
            ICellDisplay cellDisplayPrefab,
            IHideable actionPanel) :
            base
            (
                turnManager,
                commandHistory,
                validAttackProvider,
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
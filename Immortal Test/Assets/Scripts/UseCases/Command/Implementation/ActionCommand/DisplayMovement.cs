using System;

using Immortal.UnitSystem;
using Immortal.CellSystem;
using Immortal.Presenter;
using Immortal.Command;

namespace Immortal.CommandImplementation
{
    public class DisplayMovement : DisplayRange
    {
        public DisplayMovement
        (
            ITurnManager turnManager,
            ICommandHistory commandHistory,
            IValidCellProvider validMoveProvider,
            ICellDisplays cellDisplays,
            ICellDisplay cellDisplayPrefab,
            IHideable actionPanel) :
            base
            (
                turnManager,
                commandHistory,
                validMoveProvider,
                cellDisplays,
                cellDisplayPrefab,
                actionPanel
            )
        {
        }

        protected override int GetRange(IUnit currentUnit)
        {
            var moveable = currentUnit.GetComponent<IMoveable>();

            if (moveable == null)
            {
                throw new Exception("Failed to fetch moveable on DisplayMovement command!");
            }

            return moveable.CurrentMovePoints;
        }
    }
}
using System;
using Immortal.UnitSystem;

namespace Immortal.App
{
    public class DisplayMovement : DisplayRange
    {
        public DisplayMovement
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
            var moveable = currentUnit.GetComponent<IMoveable>();

            if (moveable == null)
            {
                throw new Exception("Failed to fetch moveable on DisplayMovement command!");
            }

            return moveable.CurrentMovePoints;
        }
    }
}
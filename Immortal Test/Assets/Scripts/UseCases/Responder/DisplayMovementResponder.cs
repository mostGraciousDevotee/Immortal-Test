using System;
using Immortal.CellSystem;
using Immortal.UnitSystem;

namespace Immortal.ResponderImpl
{
    public class DisplayMovementResponder : DisplayRangeResponder
    {
        public DisplayMovementResponder
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
            var moveable = currentUnit.GetComponent<IMoveable>();

            if (moveable == null)
            {
                throw new Exception("Failed to fetch moveable on DisplayMovement command!");
            }

            return moveable.CurrentMovePoints;
        }
    }
}
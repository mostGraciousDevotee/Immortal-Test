using System;
using Immortal.Entities;

namespace Immortal.App
{
    public class DisplayMovement : ActionCommand
    {
        IMovementValidator _movementValidator;
        ICellDisplays _moveDisplays;
        ICellDisplay _moveDisplayPrefab;
        
        public DisplayMovement
        (
            ITurnManager turnManager,
            IMovementValidator movementValidator,
            ICellDisplays moveDisplay,
            ICellDisplay cellDisplayPrefab
        ) : base(turnManager)
        {
            _movementValidator = movementValidator;

            _moveDisplays = moveDisplay;
            _moveDisplayPrefab = cellDisplayPrefab;
        }

        public override void Execute()
        {
            var currentUnit = _turnManager.CurrentUnit;
            var unitPos = currentUnit.Position;
            var moveable = currentUnit.GetComponent<IMoveable>();

            if (moveable == null)
            {
                throw new Exception("Failed to fetch moveable on DisplayMovement command!");
            }

            var currentMovePoints = moveable.CurrentMovePoints;

            var validPositions = _movementValidator.GetTraversableCells(unitPos, currentMovePoints);
            _moveDisplays.Show(_moveDisplayPrefab, validPositions);
        }
    }
}
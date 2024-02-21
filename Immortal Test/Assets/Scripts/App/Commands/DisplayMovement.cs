using System;
using Immortal.Entities;

namespace Immortal.App
{
    public class DisplayMovement : ActionCommand
    {
        IMovementValidator _movementValidator;
        ICellDisplays _moveDisplays;
        ICellDisplay _moveDisplayPrefab;
        IHideable _actionPanel;
        ICommandHistory _commandHistory;
        
        public DisplayMovement
        (
            ITurnManager turnManager,
            IMovementValidator movementValidator,
            ICellDisplays moveDisplay,
            ICellDisplay cellDisplayPrefab,
            IHideable actionPanel,
            ICommandHistory commandHistory
        ) : base(turnManager)
        {
            _movementValidator = movementValidator;
            _moveDisplays = moveDisplay;
            _moveDisplayPrefab = cellDisplayPrefab;
            _actionPanel = actionPanel;
            _commandHistory = commandHistory;
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
            _actionPanel.Hide();
            _commandHistory.Push(this);
        }

        public override void Undo()
        {
            _actionPanel.Show();
            _moveDisplays.Hide();
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Immortal.Entities;

namespace Immortal.App
{
    public class DisplayMovement : ActionCommand
    {
        List<Vector2Int> _validPositions = new List<Vector2Int>();
        ISquareCells _squareCells;
        IMovementValidator _movementValidator;
        IMoveDisplay _moveDisplay;
        
        public DisplayMovement
        (
            ITurnManager turnManager,
            ISquareCells squareCells,
            IMoveDisplay moveDisplay
        ) : base(turnManager)
        {
            _squareCells = squareCells;
            _moveDisplay = moveDisplay;
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

            // TODO: Create Unit Test for Traversable Cells
            _validPositions = _movementValidator.GetTraversableCells(unitPos, currentMovePoints);
            _moveDisplay.Show(_validPositions);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Immortal.App;
using Immortal.Entities;
using Immortal.Factory;
using UnityEngine;

namespace Immortal.Test
{
    public class MovementValidatorTest : BaseTest
    {
        public override bool Test()
        {
            var gameFactory = new GameFactory();

            var adam = gameFactory.MakeAdam();
            var adamMoveable = adam.GetComponent<IMoveable>();

            var bruce = gameFactory.MakeBruce();
            bruce.Position = Vector2Int.up;

            int squareDim = 16;
            int cellSize = 2;
            var squareCells = new SquareCells(squareDim, squareDim, cellSize);
            squareCells.AddUnit(adam);
            squareCells.AddUnit(bruce);

            var movementValidator = new MovementValidator(squareCells);
            var validCells = movementValidator.GetTraversableCells
            (
                adam.Position,
                adamMoveable.CurrentMovePoints
            );

            var negativeCell = validCells.Contains(Vector2Int.down);
            if (negativeCell)
            {
                Debug.Log("Valid cells contain negative cells");
                return false;
            }

            var occupiedCell = validCells.Contains(bruce.Position);
            if (occupiedCell)
            {
                Debug.Log("Valid cells contain occupied cells");
                return false;
            }

            var startCell = validCells.Contains(adam.Position);
            if (startCell)
            {
                Debug.Log("Valid cells contain starting position");
                return false;
            }

            var moveRangeVector = new Vector2Int(adamMoveable.CurrentMovePoints, adamMoveable.CurrentMovePoints);
            var outsideRangeCell = adam.Position + moveRangeVector + Vector2Int.up;
            var containOutsideRangeCell = validCells.Contains(outsideRangeCell);
            if (containOutsideRangeCell)
            {
                Debug.Log("Valid cells contain outsideRange cell");
            }
            if (containOutsideRangeCell)
            {
                return false;
            }

            var notContainAdamPos = Assert.AreEqual<bool>
            (
                false,
                validCells.Contains(adam.Position),
                ErrorMessage + " at not containing Adam pos!"
            );

            var notContainBrucePos = Assert.AreEqual<bool>
            (
                false,
                validCells.Contains(bruce.Position),
                ErrorMessage + " at not containing Bruce pos"
            );

            return
                notContainAdamPos &&
                notContainBrucePos;
        }
    }
}
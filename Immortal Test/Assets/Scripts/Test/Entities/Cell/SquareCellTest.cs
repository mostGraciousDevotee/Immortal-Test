using Immortal.CellImplementation;
using Immortal.UnitImplementation;
using UnityEngine;

namespace Immortal.Test
{
    public class SquareCellTest : BaseTest
    {
        public override bool Test()
        {
            var squareDim = 16;
            var cellSize = 2;
            var squareCells = new SquareCells(squareDim, squareDim, cellSize);

            var outsideVector = new Vector2Int(squareDim, squareDim);
            var notOutside = Assert.AreEqual<bool>
            (
                false,
                squareCells.IsInside(outsideVector),
                ErrorMessage + " at outsideVector"
            );

            var boundaryVector = new Vector2Int(squareDim - 1, squareDim - 1);
            var atBoundary = Assert.AreEqual<bool>
            (
                true,
                squareCells.IsInside(boundaryVector),
                ErrorMessage + " at boundaryVector"
            );

            var midVector = new Vector2Int(squareDim / 2, squareDim / 2);
            var atMid = Assert.AreEqual<bool>
            (
                true,
                squareCells.IsInside(midVector),
                ErrorMessage + " at MidVector"
            );

            var gameFactory = new GameFactory();
            var adam = gameFactory.MakeAdam();
            var bruce = gameFactory.MakeBruce();
            adam.Position = Vector2Int.zero;
            bruce.Position = Vector2Int.up;

            squareCells.AddUnit(adam);
            squareCells.AddUnit(bruce);

            var posZeroOccupied = Assert.AreEqual<bool>
            (
                true,
                squareCells.IsOccupied(Vector2Int.zero),
                ErrorMessage + " at posZeroOccupied"
            );

            var pos01Occupied = Assert.AreEqual<bool>
            (
                true,
                squareCells.IsOccupied(bruce.Position),
                ErrorMessage + " at pos01Occupied"
            );

            var midPosFree = Assert.AreEqual<bool>
            (
                false,
                squareCells.IsOccupied(midVector),
                ErrorMessage + " at midPosFree"
            );
            
            return
                notOutside &&
                atBoundary &&
                atMid &&
                posZeroOccupied &&
                pos01Occupied &&
                midPosFree;
        }
    }
}
using UnityEngine;
using Immortal.FactoryImplementation;

namespace Immortal.Test
{
    public class CellTest : BaseTest
    {
        public override bool Test()
        {
            var origin = Vector2Int.zero;
            var right = Vector2Int.right;
            var up = Vector2Int.up;

            var cellOrigin = new Cell(origin);
            var rightCell = new Cell(right);
            var upCell = new Cell(up);

            bool isOrigin = Assert.AreEqual<Vector2Int>(origin, cellOrigin.Position, ErrorMessage);
            bool isRight = Assert.AreEqual<Vector2Int>(right, rightCell.Position, ErrorMessage);
            bool isUp = Assert.AreEqual<Vector2Int>(up, upCell.Position, ErrorMessage);

            return isOrigin && isRight && isUp;
        }
    }
}
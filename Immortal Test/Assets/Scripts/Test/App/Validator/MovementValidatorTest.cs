using System.Collections.Generic;
using Immortal.App;
using Immortal.Entities;
using Immortal.Factory;
using UnityEngine;

namespace Immortal.Test
{
    public class MovementValidatorTest : CellValidatorTest
    {
        int _range;
        
        protected override void GetRange()
        {
            _range = _adam.GetComponent<IMoveable>().CurrentMovePoints;
        }
        
        protected override Vector2Int CreateOutsideRangeCell()
        {
            var rangeVector = new Vector2Int(_range, _range);

            return rangeVector + Vector2Int.one;
        }

        protected override void GetValidCells()
        {
            var startPos = _adam.Position;
            _validCells = _gameFactory.MakeMovementValidator().GetValidCells(_adam.Position, _range);
        }

        protected override bool IsValid()
        {
            var containingAdam = Assert.IsContaining
            (
                _validCells,
                _adam.Position,
                "Valid cells containing Adam position"
            );

            var containingBruce = Assert.IsContaining
            (
                _validCells,
                _bruce.Position,
                "Valid cells containing Bruce position"
            );

            return !containingAdam && !containingBruce;
        }
    }
}
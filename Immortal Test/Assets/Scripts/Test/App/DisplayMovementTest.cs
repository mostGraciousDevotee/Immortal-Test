using UnityEngine;
using Immortal.App;
using Immortal.Entities;

namespace Immortal.Test
{
    public class DisplayMovementTest : ActionCommandTest
    {
        IUnit _adam;
        Vector2Int _unitPos;
        
        protected override void GetUnit()
        {
            _adam = _factory.MakeAdam();
            _unitPos = _adam.Position;

            int moveRange = 2;
            var moveable = new Moveable(moveRange);

            _adam.AddComponent<IMoveable>(moveable);

        }
        
        protected override void BuildTurnManager()
        {
            _turnManager.AddUnit(_adam);
        }

        protected override void GetCommand()
        {
            int width = 16;
            int length = 16;
            int cellSize = 2;
            
            var squareCells = new SquareCells(width, length, cellSize);
            // _command = new DisplayMovement(_turnManager, squareCells);
        }

        protected override bool Validate()
        {
            return false;
        }
    }
}


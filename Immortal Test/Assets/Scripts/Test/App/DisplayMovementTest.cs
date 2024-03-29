using Immortal.CellImplementation;
using Immortal.UnitSystem;

namespace Immortal.Test
{
    public class DisplayMovementTest : ActionCommandTest
    {
        IUnit _adam;
        
        protected override void GetUnit()
        {
            _adam = _unitFactory.MakeAdam();
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
            // _command = new DisplayMovement(_turnManager, squareCells, );
        }

        protected override bool Validate()
        {
            return false;
        }
    }
}
using Immortal.CellSystem;

namespace Immortal.CellImplementation
{
    public class ValidMovementProvider : ValidCellProvider
    {
        public ValidMovementProvider(ISquareCells squareCells) : base(squareCells)
        {
            
        }

        protected override bool IsCellValid()
        {
            return !_squareCells.IsOccupied(_currentPos);
        }
    }
}
using Immortal.CellSystem;

namespace Immortal.App
{
    public class MovementValidator : CellValidator
    {
        public MovementValidator(ISquareCells squareCells) : base(squareCells)
        {
            
        }

        protected override bool IsCellValid()
        {
            return !_squareCells.IsOccupied(_currentPos);
        }
    }
}
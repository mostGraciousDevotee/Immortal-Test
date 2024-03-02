using Immortal.CellSystem;

namespace Immortal.CellImplementation
{
    public class ValidAttackProvider : ValidCellProvider
    {
        public ValidAttackProvider(ISquareCells squareCells) : base(squareCells)
        {

        }

        protected override bool IsCellValid()
        {
            return true;
        }
    }
}
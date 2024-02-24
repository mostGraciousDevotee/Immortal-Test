using Immortal.CellSystem;
using Immortal.UnitSystem;

namespace Immortal.App
{
    public class AttackValidator : CellValidator
    {
        public AttackValidator(ISquareCells squareCells) : base(squareCells)
        {

        }

        protected override bool IsCellValid()
        {
            return true;
        }
    }
}
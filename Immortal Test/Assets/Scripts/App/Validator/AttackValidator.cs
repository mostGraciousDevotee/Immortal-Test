using Immortal.Entities;

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
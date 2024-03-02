using Immortal.CellFactoryPackage;
using Immortal.CellSystem;

namespace Immortal.CellImplementation
{
    public class CellFactory : ICellFactory
    {
        ISquareCells _squareCells;
        IValidCellProvider _validMoveProvider;
        IValidCellProvider _validAttackProvider;
        
        public ISquareCells GetSquareCells()
        {
            var squareDim = 16;
            var cellSize = 2;

            if (_squareCells == null)
            {
                _squareCells = new SquareCells(squareDim, squareDim, cellSize);
            }

            return _squareCells;
        }

        public IValidCellProvider GetValidAttackProvider()
        {
            if (_validAttackProvider == null)
            {
                _validAttackProvider = new ValidAttackProvider(GetSquareCells());
            }

            return _validAttackProvider;
        }

        public IValidCellProvider GetValidMoveProvider()
        {
            if (_validMoveProvider == null)
            {
                _validMoveProvider = new ValidMovementProvider(GetSquareCells());
            }

            return _validMoveProvider;
        }
    }
}
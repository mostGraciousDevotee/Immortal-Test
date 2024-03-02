using Immortal.CellSystem;

namespace Immortal.CellFactoryPackage
{
    // TODO : SquareCell and ValidCellProvider should be
    // separated.
    public interface ICellFactory
    {
        ISquareCells GetSquareCells();
        
        IValidCellProvider GetValidMoveProvider();
        IValidCellProvider GetValidAttackProvider();
    }
}
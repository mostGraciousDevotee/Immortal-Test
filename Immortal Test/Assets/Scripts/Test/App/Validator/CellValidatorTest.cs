using System.Collections.Generic;
using UnityEngine;

using Immortal.UnitSystem;
using Immortal.CellSystem;

using Immortal.CellFactoryPackage;
using Immortal.UnitFactoryPackage;

using Immortal.UnitImplementation;
using Immortal.CellImplementation;

namespace Immortal.Test
{
    public abstract class CellValidatorTest : BaseTest
    {
        protected IUnitFactory _unitFactory;
        protected ICellFactory _cellFactory;

        protected IUnit _adam;
        protected IUnit _bruce;

        ISquareCells _squareCells;

        protected int _range;
        protected List<Vector2Int> _validCells;

        public override bool Test()
        {
            MakeGameFactory();
            MakeUnits();
            MakeSquareCells();

            GetRange();
            GetValidCells();

            var notContainingNegativeCells = Assert.AreEqual<bool>
            (
                false,
                _validCells.Contains(Vector2Int.down),
                "Valid cells containing negative cells"
            );

            var outsideRangeCell = CreateOutsideRangeCell();
            var notContainingOutsideRangeCell = Assert.AreEqual<bool>
            (
                false,
                _validCells.Contains(outsideRangeCell),
                "Valid cells containing outsideRangeCell"
            );

            return
                notContainingNegativeCells &&
                notContainingOutsideRangeCell &&
                IsValid();
        }

        protected abstract void GetRange();

        void MakeGameFactory()
        {
            _unitFactory = new UnitFactory();
            _cellFactory = new CellFactory();
        }

        void MakeUnits()
        {
            _adam = _unitFactory.MakeAdam();
            _bruce = _unitFactory.MakeBruce();

            _adam.Position = Vector2Int.zero;
            _bruce.Position = Vector2Int.up;
        }

        void MakeSquareCells()
        {
            _squareCells = _cellFactory.GetSquareCells();
            _squareCells.AddUnit(_adam);
            _squareCells.AddUnit(_bruce);
        }

        protected abstract void GetValidCells();
        Vector2Int CreateOutsideRangeCell()
        {
            var rangeVector = new Vector2Int(_range, _range);

            return rangeVector + Vector2Int.one;
        }
        protected abstract bool IsValid();
    }
}
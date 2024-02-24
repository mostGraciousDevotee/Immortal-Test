using System.Collections.Generic;
using Immortal.UnitSystem;
using Immortal.CellSystem;
using Immortal.InteractorFactory;
using Immortal.UnitImplementation;
using UnityEngine;
using Immortal.UnitFactoryPackage;
using Immortal.App;

namespace Immortal.Test
{
    public abstract class CellValidatorTest : BaseTest
    {
        protected IGameFactory _gameFactory;
        protected IUnitFactory _unitFactory;

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
            _gameFactory = new GameFactory();
            _unitFactory = new UnitFactory();
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
            _squareCells = _gameFactory.MakeSquareCells();
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
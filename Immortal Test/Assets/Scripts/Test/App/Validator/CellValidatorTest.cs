using System.Collections.Generic;
using Immortal.UnitSystem;
using Immortal.CellSystem;
using Immortal.EntityFactory;
using Immortal.UnitImplementation;
using UnityEngine;

namespace Immortal.Test
{
    public abstract class CellValidatorTest : BaseTest
    {
        protected IGameFactory _gameFactory;

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

            Debug.Log("cell count: " + _validCells.Count);

            foreach (Vector2Int vector2 in _validCells)
            {
                Debug.Log(vector2);
            }

            var outsideRangeCell = CreateOutsideRangeCell();
            var notContainingOutsideRangeCell = Assert.AreEqual<bool>
            (
                false,
                _validCells.Contains(outsideRangeCell),
                "Valid cells containing outsideRangeCell"
            );

            Debug.Log("IsValid is " + IsValid());

            return
                notContainingNegativeCells &&
                notContainingOutsideRangeCell &&
                IsValid();
        }

        protected abstract void GetRange();

        void MakeGameFactory()
        {
            _gameFactory = new GameFactory();
            Debug.Log("Making GameFactory");
        }

        void MakeUnits()
        {
            _adam = _gameFactory.MakeAdam();
            _bruce = _gameFactory.MakeBruce();

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
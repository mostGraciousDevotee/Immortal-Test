using System;
using System.Collections.Generic;
using Immortal.App;
using Immortal.Entities;
using Immortal.Factory;
using UnityEngine;

namespace Immortal.Test
{
    public abstract class CellValidatorTest : BaseTest
    {
        protected IGameFactory _gameFactory;

        protected IUnit _adam;
        protected IUnit _bruce;

        ISquareCells _squareCells;

        protected List<Vector2Int> _validCells;

        public override bool Test()
        {
            MakeGameFactory();
            MakeUnits();
            MakeSquareCells();

            GetRange();
            GetValidCells();

            var containNegativeCells = Assert.IsContaining<Vector2Int>
            (
                _validCells,
                Vector2Int.down,
                "Valid cells contain negative cell"
            );

            var outsideRangeCell = CreateOutsideRangeCell();
            var containOutsideRangeCell = Assert.IsContaining<Vector2Int>
            (
                _validCells,
                outsideRangeCell,
                "Valid cells contain outside range cell"
            );

            return
                !containNegativeCells &&
                !containOutsideRangeCell &&
                IsValid();
        }

        protected abstract void GetRange();

        void MakeGameFactory()
        {
            _gameFactory = new GameFactory();
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
        protected abstract Vector2Int CreateOutsideRangeCell();
        protected abstract bool IsValid();
    }
}
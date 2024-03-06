using System;
using System.Collections.Generic;
using UnityEngine;

using Immortal.UnitSystem;
using Immortal.CellSystem;
using Immortal.Responder;

namespace Immortal.ResponderImpl
{
    public abstract class DisplayRangeResponder : IDisplayRangeResponder
    {
        protected string _displayType;
        ITurnManager _turnManager;
        ISquareCells _squareCells;
        IValidCellProvider _cellProvider;

        protected DisplayRangeResponder
        (
            string displayType,
            ITurnManager turnManager,
            ISquareCells squareCells,
            IValidCellProvider cellProvider
        )
        {
            _displayType = displayType;
            _turnManager = turnManager;
            _squareCells = squareCells;
            _cellProvider = cellProvider;
        }
        
        public event Action<string, int, List<Vector2Int>> ShowValidRange;
        public event Action Unshow;

        public void Respond()
        {
            var currentUnit = _turnManager.CurrentUnit;
            var unitPos = currentUnit.Position;

            var range = GetRange(currentUnit);
            var cellSize = _squareCells.CellSize;

            var validPositions = _cellProvider.GetValidCells(unitPos, range);

            ShowValidRange?.Invoke(_displayType, cellSize, validPositions);
        }

        public void Unrespond()
        {
            Unshow?.Invoke();
        }

        protected abstract int GetRange(IUnit currentUnit);
    }
}
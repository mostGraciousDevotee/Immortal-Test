using UnityEngine;
using System;
using Immortal.UnitSystem;
using Immortal.CellSystem;

namespace Immortal.CellImplementation
{
    public class SquareCells : ISquareCells
    {
        int _width;
        int _length;
        int _cellSize;
        ICell[,] _cells;

        public SquareCells(int width, int length, int cellSize)
        {
            _width = width;
            _length = length;
            _cellSize = cellSize;
            _cells = new Cell[width, length];

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    // TODO: Cell can be provided by factory
                    _cells[x, z] = new Cell(new Vector2Int(x, z));
                }
            }
        }

        public event Action<IUnit> UnitAdded;

        public int Width => _width;
        public int Length => _length;
        public int CellSize => _cellSize;
        
        public bool IsInside(Vector2Int pos)
        {
            bool insideHorizontally = pos.x >= 0 && pos.x < _width;
            bool insideVertically = pos.y >= 0 && pos.y < _length;

            return insideHorizontally && insideVertically;
        }

        public void AddUnit(IUnit unit)
        {
            var cell = _cells[unit.Position.x, unit.Position.y];

            if (!cell.IsOccupied)
            {
                cell.AddUnit(unit);
                UnitAdded?.Invoke(unit);
            }
            else
            {
                throw new Exception("Trying to add Unit to already occupied cells!");
            }
        }

        public bool IsOccupied(Vector2Int pos)
        {
            var isCellOccupied = false;

            if (IsInside(pos))
            {
                isCellOccupied = _cells[pos.x, pos.y].IsOccupied;
            }

            return isCellOccupied;
        }
    }
}
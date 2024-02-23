using UnityEngine;
using Immortal.Entities;

namespace Immortal.FactoryImplementation
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
            _cells[unit.Position.x, unit.Position.y].AddUnit(unit);
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
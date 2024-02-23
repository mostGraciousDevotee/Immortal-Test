using UnityEngine;

namespace Immortal.Entities
{
    public interface ISquareCells
    {
        int Width { get; }
        int Length { get; }
        int CellSize { get; }

        void AddUnit(IUnit unit);

        bool IsInside(Vector2Int pos);
        bool IsOccupied(Vector2Int pos);
    }
}
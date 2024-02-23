using UnityEngine;

namespace Immortal.Entities
{
    public interface ICell
    {
        Vector2Int Position { get; }
        bool IsOccupied { get; }

        void AddUnit(IUnit unit);
        void RemoveUnit();
        IUnit GetOccupyingUnit();
    }
}
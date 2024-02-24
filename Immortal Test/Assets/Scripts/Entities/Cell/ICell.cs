using UnityEngine;
using Immortal.UnitSystem;

namespace Immortal.CellSystem
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
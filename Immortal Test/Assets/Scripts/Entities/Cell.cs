using UnityEngine;

namespace Immortal.Entities
{
    public class Cell : ICell
    {
        Vector2Int _position;
        bool _isOccupied;
        IUnit _occupyingUnit;

        public Cell(Vector2Int position)
        {
            _position = position;
        }

        public Vector2Int Position => _position;

        public void AddUnit(IUnit unit)
        {
            if (_isOccupied)
            {
                return;
            }

            _occupyingUnit = unit;
            _isOccupied = true;
        }
        public void RemoveUnit()
        {
            _isOccupied = false;
            _occupyingUnit = null;
        }
        public IUnit GetOccupyingUnit()
        {
            return _occupyingUnit;
        }
    }

    public interface ICell
    {
        Vector2Int Position{get; }
        
        void AddUnit(IUnit unit);
        void RemoveUnit();
        IUnit GetOccupyingUnit();
    }
}
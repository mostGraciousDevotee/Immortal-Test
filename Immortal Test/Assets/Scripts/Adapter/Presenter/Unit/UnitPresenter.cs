using System;
using UnityEngine;

using Immortal.UnitSystem;
using Immortal.Presenter;
using Immortal.UnitPresenterSystem;

namespace Immortal.PresenterImplementation
{
    public class UnitPresenter : MonoBehaviour, IUnitPresenter, IMarkable
    {
        IUnit _unit;
        int _cellSize;

        public void Init(IUnit unit, int cellSize)
        {
            _unit = unit;
            _cellSize = cellSize;

            unit.UnitActive += OnUnitActive;
            unit.PositionChanged += SetPosition;
        }
        
        public event Action<IMarkable> UnitPresenterActive;

        public void SetPosition(Vector2Int position)
        {
            transform.position = new Vector3
            (
                position.x * _cellSize,
                transform.position.y,
                position.y * _cellSize);
        }

        void OnUnitActive()
        {
            UnitPresenterActive?.Invoke(this);
        }
    }
}
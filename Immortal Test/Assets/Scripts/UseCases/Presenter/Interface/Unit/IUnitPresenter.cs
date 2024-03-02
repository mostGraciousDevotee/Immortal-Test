using System;
using Immortal.Presenter;
using Immortal.UnitSystem;
using UnityEngine;

namespace Immortal.UnitPresenterSystem
{
    public interface IUnitPresenter
    {
        event Action<IMarkable> UnitPresenterActive;

        void Init(IUnit unit, int cellSize);
        void SetPosition(Vector2Int position);
    }
}
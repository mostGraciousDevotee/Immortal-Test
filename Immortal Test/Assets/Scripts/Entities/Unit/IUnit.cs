using System;
using UnityEngine;

namespace Immortal.UnitSystem
{
    public interface IUnit
    {
        event Action<IUnit> UnitReady;
        event Action<Vector2Int> PositionChanged;

        string Name { get; }
        int Speed { get; }

        Vector2Int Position { get; set; }

        void UpdateReadiness();
        void EndTurn();
        void AddComponent<T>(T component) where T : IComponent;
        T GetComponent<T>() where T : IComponent;
    }
}
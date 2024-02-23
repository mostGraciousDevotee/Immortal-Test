using System;
using System.Collections.Generic;
using Immortal.Entities;
using UnityEngine;

namespace Immortal.FactoryImplementation
{
    public class Unit : IUnit
    {
        const int READY_TO_ACT = 100;
        
        string _name;
        int _speed;
        int _readiness;

        Vector2Int _position;
        
        public Unit(string name, int speed)
        {
            _name = name;
            _speed = speed;
            _position = Vector2Int.zero;
        }

        Dictionary<Type, IComponent> _components = new Dictionary<Type, IComponent>();

        public event Action<IUnit> UnitReady;
        public event Action<Vector2Int> PositionChanged;

        public string Name => _name;
        public int Speed => _speed;
        public Vector2Int Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(_position);
            } 
        }

        public void UpdateReadiness()
        {
            _readiness += _speed;

            if (_readiness >= READY_TO_ACT)
            {
                _readiness -= READY_TO_ACT;
                UnitReady?.Invoke(this);
            }
        }

        public void EndTurn()
        {
            
        }

        public void AddComponent<T>(T component) where T : IComponent
        {
            _components[typeof(T)] = component;
        }

        public T GetComponent<T>() where T : IComponent
        {
            if (_components.TryGetValue(typeof(T), out IComponent component))
            {
                return (T)component;
            }
            else
            {
                return default(T);
            }
        }
    }
}
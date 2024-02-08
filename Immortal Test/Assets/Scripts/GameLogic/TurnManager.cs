using System;
using System.Collections.Generic;
using Immortal.Entities;
using UnityEngine;

namespace Immortal.GameLogic
{
    public class TurnManager : ITurnManager
    {
        bool _hasStarted;
        int _processGuard;

        IUnit _currentUnit;
        List<IUnit> _unitList = new List<IUnit>();
        Queue<IUnit> _unitQueue = new Queue<IUnit>();
        
        public event Action<IUnit> UnitActive;

#region AddRemoveUnit
        public void AddUnit(IUnit unit)
        {
            _unitList.Add(unit);
            unit.UnitReady += Enqueue;
        }

        void RemoveUnit(IUnit unit)
        {
            unit.UnitReady -= Enqueue;
            _unitList.Remove(unit);
        }

        void Enqueue(IUnit unit)
        {
            _unitQueue.Enqueue(unit);
        }
#endregion

#region StartAndProcess
        public void Start()
        {
            StartGuard();
            _hasStarted = true;
            ProcessUnitTurn();
        }

        void StartGuard()
        {
            if (_hasStarted)
            {
                Debug.Log("A process is attempting to start a running TurnManager");
                return;
            }
        }

        void ProcessUnitTurn()
        {   
            if (UnitInQueue())
            {
                _processGuard = 0;
                _currentUnit = _unitQueue.Dequeue();
                UnitActive?.Invoke(_currentUnit);
                // if (_currentUnit.IsPlayerControlled)
                // {
                    // PlayerUnitActive?.Invoke();
                // }
            }
            else
            {
                _processGuard++;
                ProcessGuard();
                UpdateUnitReadiness();
                ProcessUnitTurn();
            }
        }

        void ProcessGuard()
        {
            if (_processGuard >= 100)
            {
                throw new Exception("TurnManager Process overflow");
            }
        }

        bool UnitInQueue()
        {
            return _unitQueue.TryPeek(out IUnit unit);
        }

        void UpdateUnitReadiness()
        {
            foreach (IUnit unit in _unitList)
            {
                unit.UpdateReadiness();
            }
        }
#endregion

#region Dispose
        public void Dispose()
        {
            RemoveAllUnits();
        }

        void RemoveAllUnits()
        {
            IgnoreUnits();
            _unitList.Clear();
            _unitQueue.Clear();
        }

        void IgnoreUnits()
        {
            foreach (IUnit unit in _unitList)
            {
                unit.UnitReady -= Enqueue;
            }

            foreach (IUnit unit in _unitQueue)
            {
                unit.UnitReady -= Enqueue;
            }
        }
#endregion
    }

    public interface ITurnManager : IDisposable
    {
        public event Action<IUnit> UnitActive;
        public void AddUnit(IUnit unit);
        public void Start();
    }
}
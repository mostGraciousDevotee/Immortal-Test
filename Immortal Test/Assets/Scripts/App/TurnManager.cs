using System;
using System.Collections.Generic;
using Immortal.Entities;

namespace Immortal.App
{
    public class TurnManager : ITurnManager
    {
        int _processGuard;

        // TODO: TurnManager should work with SquareCells or ICells
        // as the cells is the validator when unit is added to the
        // game
        IUnit _currentUnit;
        List<IUnit> _unitList = new List<IUnit>();
        Queue<IUnit> _unitQueue = new Queue<IUnit>();
        
        public event Action<IUnit> UnitActive;

        public IUnit CurrentUnit => _currentUnit;

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
            ProcessUnitTurn();
        }

        public void EndTurn()
        {
            _currentUnit.EndTurn();
            ProcessUnitTurn();
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
        event Action<IUnit> UnitActive;

        IUnit CurrentUnit {get; }
        
        void AddUnit(IUnit unit);
        void Start();
        void EndTurn();
    }
}
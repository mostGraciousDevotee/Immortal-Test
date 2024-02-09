using System;

namespace Immortal.Entities
{
    public class Unit : IUnit
    {
        const int READY_TO_ACT = 100;
        
        string _name;
        int _speed;
        int _readiness;
        
        public Unit(string name, int speed)
        {
            _name = name;
            _speed = speed;
        }

        public event Action<IUnit> UnitReady;

        public string Name => _name;
        public int Speed => _speed;

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
    }

    public interface IUnit
    {
        event Action<IUnit> UnitReady;
        string Name { get; }
        int Speed { get; }
        void UpdateReadiness();
        void EndTurn();
    }
}
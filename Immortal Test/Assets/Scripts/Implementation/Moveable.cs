using System;
using Immortal.Entities;

namespace Immortal.FactoryImplementation
{
    public class Moveable : IMoveable
    {
        int _maxMovePoints;
        int _currentMovePoints;

        public event Action<IMoveable> MovePointChanged;

        public Moveable(int moveRange)
        {
            _maxMovePoints = moveRange;
            _currentMovePoints = moveRange;
        }

        public int MaxMovePoints => _maxMovePoints;
        public int CurrentMovePoints
        {
            get
            {
                return _currentMovePoints;
            }
            set
            {
                _currentMovePoints = value;
                _currentMovePoints = _currentMovePoints > 0 ? _currentMovePoints : 0;
                MovePointChanged?.Invoke(this);
            }
        }
    }
}
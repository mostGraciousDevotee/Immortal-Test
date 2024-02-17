using System;

namespace Immortal.Entities
{
    public class Moveable : Component, IMoveable
    {
        int _moveRange;
        int _movePoints;

        public event Action<IMoveable> MovePointChanged;

        public Moveable(int moveRange)
        {
            _moveRange = moveRange;
            _movePoints = moveRange;
        }

        public int MoveRange => _moveRange;
        public int MovePoints
        {
            get
            {
                return _movePoints;
            }
            set
            {
                _movePoints = value;
                _movePoints = _movePoints > 0 ? _movePoints : 0;
                MovePointChanged?.Invoke(this);
            }
        }
    }

    public interface IMoveable : IComponent
    {
        event Action<IMoveable> MovePointChanged;
        int MoveRange { get; }
        int MovePoints { get; set; }
    }
}
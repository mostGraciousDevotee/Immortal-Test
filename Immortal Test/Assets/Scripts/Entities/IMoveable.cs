using System;

namespace Immortal.UnitSystem
{
    public interface IMoveable : IComponent
    {
        event Action<IMoveable> MovePointChanged;
        int MaxMovePoints { get; }
        int CurrentMovePoints { get; set; }
    }
}
using System;

namespace Immortal.Entities
{
    public interface IMoveable : IComponent
    {
        event Action<IMoveable> MovePointChanged;
        int MaxMovePoints { get; }
        int CurrentMovePoints { get; set; }
    }
}
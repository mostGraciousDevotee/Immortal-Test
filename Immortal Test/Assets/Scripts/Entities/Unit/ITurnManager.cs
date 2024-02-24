using System;

namespace Immortal.UnitSystem
{
    public interface ITurnManager : IDisposable
    {
        event Action<IUnit> UnitActive;

        IUnit CurrentUnit { get; }

        void AddUnit(IUnit unit);
        void Start();
        void EndTurn();
    }
}
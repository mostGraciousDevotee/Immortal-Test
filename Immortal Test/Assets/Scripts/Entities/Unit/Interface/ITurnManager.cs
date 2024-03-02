using System;

namespace Immortal.UnitSystem
{
    public interface ITurnManager : IDisposable
    {
        IUnit CurrentUnit { get; }

        void AddUnit(IUnit unit);
        void Start();
        void EndTurn();
    }
}
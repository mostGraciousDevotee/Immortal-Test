using Immortal.UnitSystem;

namespace Immortal.UnitFactoryPackage
{
    public interface IUnitFactory
    {
        IUnit MakeAdam();
        IUnit MakeBruce();
        ITurnManager MakeTurnManager();
    }
}
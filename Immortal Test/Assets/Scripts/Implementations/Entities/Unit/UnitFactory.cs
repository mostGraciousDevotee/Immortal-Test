using Immortal.UnitFactoryPackage;
using Immortal.UnitSystem;

namespace Immortal.UnitImplementation
{
    public class UnitFactory : IUnitFactory
    {
        ITurnManager _turnManager;
        
        public IUnit MakeAdam()
        {
            var name = "Adam";
            var speed = 10;
            var maxMovePoints = 2;
            var attackRange = 1;

            var moveable = new Moveable(maxMovePoints);
            var combatant = new Combatant(attackRange);
            var adam = new Unit(name, speed);

            adam.AddComponent<IMoveable>(moveable);
            adam.AddComponent<ICombatant>(combatant);

            return adam;
        }

        public IUnit MakeBruce()
        {
            var name = "Bruce";
            var speed = 9;
            var maxMovePoints = 4;
            var attackRange = 2;

            var moveable = new Moveable(maxMovePoints);
            var combatant = new Combatant(attackRange);
            var bruce = new Unit(name, speed);

            bruce.AddComponent<IMoveable>(moveable);
            bruce.AddComponent<ICombatant>(combatant);

            return bruce;
        }

        public ITurnManager MakeTurnManager()
        {
            if (_turnManager == null)
            {
                _turnManager = new TurnManager();
            }

            return _turnManager;
        }
    }
}
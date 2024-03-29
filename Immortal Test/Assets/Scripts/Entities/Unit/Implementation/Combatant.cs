using Immortal.UnitSystem;

namespace Immortal.UnitImplementation
{
    public class Combatant : ICombatant
    {
        int _attackRange;
        
        public Combatant(int attackRange)
        {
            _attackRange = attackRange;
        }

        public int AttackRange => _attackRange;
    }
}
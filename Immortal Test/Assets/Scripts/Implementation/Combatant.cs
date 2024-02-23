using Immortal.Entities;

namespace Immortal.FactoryImplementation
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
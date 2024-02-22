namespace Immortal.Entities
{
    public class Combatant : Component, ICombatant
    {
        int _attackRange;
        
        public Combatant(int attackRange)
        {
            _attackRange = attackRange;
        }

        public int AttackRange => _attackRange;
    }
}
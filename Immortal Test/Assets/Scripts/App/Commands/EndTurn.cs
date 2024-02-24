using Immortal.UnitSystem;

namespace Immortal.App
{
    public class EndTurn : ActionCommand
    {
        public EndTurn(ITurnManager turnManager) : base(turnManager)
        { }
        
        public override void Execute()
        {
            _turnManager.EndTurn();
        }

        public override void Undo()
        {
            
        }
    }
}
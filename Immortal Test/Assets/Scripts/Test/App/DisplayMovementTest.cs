using Immortal.App;
using Immortal.Entities;

namespace Immortal.Test
{
    public class DisplayMovementTest : ActionCommandTest
    {
        IUnit _adam;
        
        protected override void GetUnit()
        {
            _adam = _factory.MakeAdam();
        }
        
        protected override void BuildTurnManager()
        {
            _turnManager.AddUnit(_adam);
        }

        protected override void GetCommand()
        {
            _command = new DisplayMovement(_turnManager);
        }

        protected override bool Validate()
        {
            return false;
        }
    }
}


using Immortal.App;
using Immortal.Factory;

namespace Immortal.Test
{
    public abstract class ActionCommandTest : BaseTest
    {
        protected IGameFactory _factory;
        protected ITurnManager _turnManager;
        protected ICommand _command;
        
        public ActionCommandTest()
        {
            _factory = new GameFactory();
        }
        
        public override bool Test()
        {
            GetUnit();
            _turnManager = new TurnManager();
            BuildTurnManager();
            GetCommand();

            _turnManager.Start();
            
            return Validate();
        }

        protected abstract void GetCommand();
        protected abstract void GetUnit();
        protected abstract void BuildTurnManager();
        protected abstract bool Validate();
    }
}
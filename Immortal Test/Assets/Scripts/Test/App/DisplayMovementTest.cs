
using Immortal.App;

namespace Immortal.Test
{
    public abstract class ActionCommandTest : BaseTest
    {
        protected IGameFactory _gameFactory;
        protected ITurnManager _turnManager;
        protected ICommand _command;
        
        public ActionCommandTest(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public override bool Test()
        {
            GetUnit();
            _turnManager = _gameFactory.TurnManager;
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
using Immortal.App;
using Immortal.UnitFactoryPackage;
using Immortal.UnitImplementation;

namespace Immortal.Test
{
    public abstract class ActionCommandTest : BaseTest
    {
        protected IUnitFactory _unitFactory;
        protected ITurnManager _turnManager;
        protected ICommand _command;
        
        public ActionCommandTest()
        {
            _unitFactory = new UnitFactory();
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
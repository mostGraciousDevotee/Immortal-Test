using Immortal.App;
using Immortal.UnitSystem;

namespace Immortal.Test
{
    public class EndTurnTest : ActionCommandTest
    {
        IUnit _adam;
        IUnit _bruce;
        IUnit _resultUnit;

        protected override void GetUnit()
        {
            _adam = _factory.MakeAdam();
            _bruce = _factory.MakeBruce();
        }
        protected override void BuildTurnManager()
        {
            _turnManager.AddUnit(_adam);
            _turnManager.AddUnit(_bruce);
            _turnManager.UnitActive += OnUnitActive;
        }
        protected override void GetCommand()
        {
            _command = new EndTurn(_turnManager);
        }

        protected override bool Validate()
        {
            bool firstExpectedUnit =
                Assert.AreEqualRef<IUnit>(_adam, _resultUnit, this.ErrorMessage);
            _command.Execute();

            bool secondExpectedUnit =
                Assert.AreEqualRef<IUnit>(_bruce, _resultUnit, this.ErrorMessage);
            _command.Execute();

            bool thirdExpectedUnit =
                Assert.AreEqualRef<IUnit>(_adam, _resultUnit, this.ErrorMessage);

            return firstExpectedUnit && secondExpectedUnit && thirdExpectedUnit;
        }

        void OnUnitActive(IUnit unit)
        {
            _resultUnit = unit;
        }
    }
}
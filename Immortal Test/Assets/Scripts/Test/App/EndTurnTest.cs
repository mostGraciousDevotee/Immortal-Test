using Immortal.App;
using Immortal.Entities;
using Immortal.Factory;

namespace Immortal.Test
{
    public class EndTurnTest : ActionCommandTest
    {
        IUnit _adam;
        IUnit _bruce;
        IUnit _resultUnit;

        public EndTurnTest(IGameFactory gameFactory) : base(gameFactory)
        {
        }

        protected override void GetUnit()
        {
            _adam = _gameFactory.Adam;
            _bruce = _gameFactory.Bruce;
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
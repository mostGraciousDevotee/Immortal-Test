using Immortal.App;
using Immortal.Entities;
using Immortal.Factory;

namespace Immortal.Test
{
    public class EndTurnTest : BaseTest
    {
        IUnit _resultUnit;
        
        public override bool Test()
        {
            var gameFactory = new GameFactory();
            
            var turnManager = gameFactory.TurnManager;
            var endTurn = new EndTurn(turnManager);

            var adam = gameFactory.Adam;
            var bruce = gameFactory.Bruce;

            turnManager.AddUnit(adam);
            turnManager.AddUnit(bruce);
            turnManager.UnitActive += OnUnitActive;

            turnManager.Start();
            bool firstExpectedUnit =
                Assert.AreEqualRef<IUnit>(adam, _resultUnit, this.ErrorMessage);
            endTurn.Execute();
            
            bool secondExpectedUnit =
                Assert.AreEqualRef<IUnit>(bruce, _resultUnit, this.ErrorMessage);
            endTurn.Execute();

            bool thirdExpectedUnit =
                Assert.AreEqualRef<IUnit>(adam, _resultUnit, this.ErrorMessage);

            return firstExpectedUnit && secondExpectedUnit && thirdExpectedUnit;
        }

        void OnUnitActive(IUnit unit)
        {
            _resultUnit = unit;
        }
    }
}
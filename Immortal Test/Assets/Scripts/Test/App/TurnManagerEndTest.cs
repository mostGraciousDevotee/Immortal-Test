using Immortal.App;
using Immortal.Entities;

namespace Immortal.Test
{
    public class TurnManagerEndTest : BaseTest
    {
        IUnit _resultUnit;
        
        public override bool Test()
        {
            var gameFactory = new GameFactory();
            
            var turnManager = gameFactory.TurnManager;
            var expectedUnit1 = gameFactory.Adam;
            var expectedUnit2 = gameFactory.Bruce;

            turnManager.AddUnit(expectedUnit1);
            turnManager.AddUnit(expectedUnit2);
            turnManager.UnitActive += OnUnitActive;

            turnManager.Start();
            bool expectedUnit1Active =
                Assert.AreEqualRef<IUnit>(expectedUnit1, _resultUnit, this.ErrorMessage);
            turnManager.EndTurn();
            
            bool expectedUnit2Active =
                Assert.AreEqualRef<IUnit>(expectedUnit2, _resultUnit, this.ErrorMessage);
            turnManager.EndTurn();

            bool expectedUnit3Active =
                Assert.AreEqualRef<IUnit>(expectedUnit1, _resultUnit, this.ErrorMessage);

            return expectedUnit1Active && expectedUnit2Active && expectedUnit3Active;
        }

        void OnUnitActive(IUnit unit)
        {
            _resultUnit = unit;
        }
    }
}
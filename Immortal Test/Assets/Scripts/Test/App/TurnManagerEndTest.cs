using Immortal.App;
using Immortal.Entities;

namespace Immortal.Test
{
    public class TurnManagerEndTest : BaseTest
    {
        IUnit _resultUnit;

        public override bool Test()
        {
            var turnManager = new TurnManager();
            var expectedUnit1 = new Unit("Adam", 10);
            var expectedUnit2 = new Unit("Bruce", 9);

            turnManager.AddUnit(expectedUnit1);
            turnManager.AddUnit(expectedUnit2);
            turnManager.UnitActive += OnUnitActive;

            turnManager.Start();
            bool expectedUnit1Active =
                Assert.AreEqualRef<IUnit>(expectedUnit1, _resultUnit, this.ErrorMessage);
            turnManager.Endturn();
            
            bool expectedUnit2Active =
                Assert.AreEqualRef<IUnit>(expectedUnit2, _resultUnit, this.ErrorMessage);
            turnManager.Endturn();

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
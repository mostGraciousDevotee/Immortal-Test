using Immortal.GameLogic;
using Immortal.Entities;

namespace Immortal.Test
{
    public class TurnManagerStartTest : BaseTest
    {
        IUnit _resultUnit;
        
        public override bool Test()
        {
            var turnManager = new TurnManager();
            var expectedUnit = new Unit("Adam", 10);

            turnManager.AddUnit(expectedUnit);
            turnManager.UnitActive += OnUnitActive;
            turnManager.Start();

            bool unitActiveAndValid =
                Assert.AreEqualRef<IUnit>(expectedUnit, _resultUnit, this.ErrorMessage);

            turnManager.Start();

            return unitActiveAndValid;
        }

        void OnUnitActive(IUnit unit)
        {
            _resultUnit = unit;
        }
    }
}
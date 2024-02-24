using Immortal.UnitSystem;
using Immortal.UnitImplementation;

namespace Immortal.Test
{
    public class UnitReadyTest : BaseTest
    {
        IUnit _unitResult;
        int _eventCounter;

        public override bool Test()
        {
            string name = "Adam";
            int speed = 10;
            var unit = new Unit(name, speed);
            
            unit.UnitReady += UnitReadyHandler;

            bool counterAt5Ticks = false;
            bool counterAt10Ticks = false;
            bool counterAt15Ticks = false;
            bool counterAt20Ticks = false;

            int maxTick = 20;
            for (int tick = 0; tick < maxTick; tick++)
            {
                unit.UpdateReadiness();
                if (tick == 4)
                {
                    counterAt5Ticks = Assert.AreEqual<int>(0, _eventCounter, this.ErrorMessage);
                }
                else if (tick == 9)
                {
                    counterAt10Ticks = Assert.AreEqual<int>(1, _eventCounter, this.ErrorMessage);
                }
                else if (tick == 14)
                {
                    counterAt15Ticks = Assert.AreEqual<int>(1, _eventCounter, this.ErrorMessage);
                }
                else if (tick == 19)
                {
                    counterAt20Ticks = Assert.AreEqual<int>(2, _eventCounter, this.ErrorMessage);
                }
            }

            bool unitIsEqual = Assert.AreEqualRef<IUnit>(unit, _unitResult, this.ErrorMessage);

            unit.UnitReady -= UnitReadyHandler;

            return
                unitIsEqual &&
                counterAt5Ticks &&
                counterAt10Ticks &&
                counterAt15Ticks &&
                counterAt20Ticks;
        }

        void UnitReadyHandler(IUnit unit)
        {
            _unitResult = unit;
            _eventCounter++;
        }
    }
}
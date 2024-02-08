using Immortal.Entities;

namespace Immortal.Test
{
    public class UnitPropertyTest : BaseTest
    {
        public override bool Test()
        {
            string name = "Adam";
            int speed = 10;

            var unit = new Unit(name, speed);

            bool nameIsEqual = Assert.AreEqual<string>(name, unit.Name, this.ErrorMessage);
            bool speedIsEqual = Assert.AreEqual<int>(speed, unit.Speed, this.ErrorMessage);

            return nameIsEqual && speedIsEqual;
        }
    }
}


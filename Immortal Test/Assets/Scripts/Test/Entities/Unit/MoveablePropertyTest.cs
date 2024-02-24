using Immortal.UnitSystem;
using Immortal.UnitImplementation;

namespace Immortal.Test
{
    public class MoveablePropertyTest : BaseTest
    {
        public override bool Test()
        {
            string name = "Adam";
            int speed = 10;
            int moveRange = 2;

            var unit = new Unit(name, speed);
            var moveable = new Moveable(moveRange);

            unit.AddComponent<IMoveable>(moveable);

            var resultMoveable = unit.GetComponent<IMoveable>();

            bool addedMoveable = Assert.AreEqualRef<IMoveable>(moveable, resultMoveable, this.ErrorMessage);

            if (resultMoveable == null)
            {
                return addedMoveable;
            }

            bool addedMoveRange = Assert.AreEqual<int>(moveRange, resultMoveable.MaxMovePoints, this.ErrorMessage);

            return addedMoveRange;
        }
    }
}
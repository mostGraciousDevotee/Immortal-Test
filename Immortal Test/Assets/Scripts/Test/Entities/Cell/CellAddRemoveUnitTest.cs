using Immortal.Entities;
using UnityEngine;

namespace Immortal.Test
{
    public class CellAddRemoveUnitTest : BaseTest
    {
        public override bool Test()
        {
            var adam = new Unit("Adam", 10);
            var bruce = new Unit("Bruce", 9);

            var originCell = new Cell(Vector2Int.zero);

            originCell.AddUnit(adam);
            originCell.AddUnit(bruce);

            bool isAdamAtOrigin = Assert.AreEqualRef<IUnit>(adam, originCell.GetOccupyingUnit(), ErrorMessage);

            originCell.RemoveUnit();
            originCell.AddUnit(bruce);

            bool isBruceAtOrigin = Assert.AreEqualRef<IUnit>(bruce, originCell.GetOccupyingUnit(), ErrorMessage);

            return isAdamAtOrigin && isBruceAtOrigin;
        }
    }
}
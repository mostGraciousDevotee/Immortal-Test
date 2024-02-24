using Immortal.UnitImplementation;
using UnityEngine;

namespace Immortal.Test
{
    public class UnitPositionChangedTest : BaseTest
    {
        Vector2Int _resultPos;
        
        public override bool Test()
        {
            var unitFactory = new UnitFactory();

            var adam = unitFactory.MakeAdam();
            var vector19 = new Vector2Int(19, 19);
            
            adam.PositionChanged += OnPositionChanged;
            adam.Position = vector19;

            var correctPosition = Assert.AreEqual<Vector2Int>
            (
                vector19,
                _resultPos,
                ErrorMessage + " position is incorrect!"
            );

            adam.PositionChanged -= OnPositionChanged;

            return correctPosition;
        }

        void OnPositionChanged(Vector2Int pos)
        {
            _resultPos = pos;
        }
    }
}
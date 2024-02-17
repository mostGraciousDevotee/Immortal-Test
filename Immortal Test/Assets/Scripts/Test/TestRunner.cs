using System.Collections.Generic;
using Immortal.Factory;
using UnityEngine;

namespace Immortal.Test
{
    public class TestRunner : MonoBehaviour
    {
        List<BaseTest> _tests = new List<BaseTest>();
        
        void Start()
        {
            var gameFactory = new GameFactory();
            
            AddTest(new UnitPropertyTest());
            AddTest(new UnitReadyTest());

            AddTest(new EndTurnTest());

            AddTest(new CellTest());
            AddTest(new CellAddRemoveUnitTest());

            // var gameTest = new LoadNewGameTest();
            // _tests.Add(gameTest);

            foreach(BaseTest test in _tests)
            {
                if (test.Test() != true)
                {
                    Debug.LogError(test.ToString() + " run failed!");
                    return;
                }
            }

            Debug.Log("All test passed! Congratulations Faikar!");
        }

        void AddTest(BaseTest test)
        {
            _tests.Add(test);
        }
    }
}   
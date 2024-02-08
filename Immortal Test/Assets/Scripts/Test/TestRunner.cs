using System.Collections.Generic;
using UnityEngine;

namespace Immortal.Test
{
    public class TestRunner : MonoBehaviour
    {
        List<BaseTest> _tests = new List<BaseTest>();
        
        void Start()
        {
            var unitPropertyTest = new UnitPropertyTest();
            var unitReadyTest = new UnitReadyTest();
            var turnManagerStartTest = new TurnManagerStartTest();

            _tests.Add(unitPropertyTest);
            _tests.Add(unitReadyTest);
            _tests.Add(turnManagerStartTest);

            foreach(BaseTest test in _tests)
            {
                if (test.Test() != true)
                {
                    Debug.LogError("Test run failed!");
                    return;
                }
            }

            Debug.Log("All test passed! Congratulations Faikar!");
        }
    }
}   
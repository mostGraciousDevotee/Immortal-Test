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

            _tests.Add(unitPropertyTest);

            foreach(BaseTest test in _tests)
            {
                if (test.Test() != true)
                {
                    return;
                }
            }

            Debug.Log("All test passed! Congratulations Faikar!");
        }
    }
}   
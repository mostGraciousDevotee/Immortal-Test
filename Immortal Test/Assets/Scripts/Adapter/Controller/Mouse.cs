using System;
using UnityEngine;
using Immortal.Controller;

namespace Immortal.ControllerImplementation
{
    // TODO : If no other package beside main called the IMouse
    // IMouse should be deleted.
    public class Mouse : MonoBehaviour, IMouse
    {   
        public event Action RightMouseButtonDown; 

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RightMouseButtonDown?.Invoke();
            }
        }
    }
}
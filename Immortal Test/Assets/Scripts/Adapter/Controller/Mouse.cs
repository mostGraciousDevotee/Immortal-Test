using System;
using UnityEngine;
using Immortal.Controller;

namespace Immortal.ControllerImplementation
{
    public class Mouse : MonoBehaviour, IMouse
    {   
        public event Action RightMouseButtonDown; 

        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RightMouseButtonDown?.Invoke();
            }
        }
    }
}
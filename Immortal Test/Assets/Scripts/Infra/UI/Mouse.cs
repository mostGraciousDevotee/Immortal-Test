using System;
using UnityEngine;

namespace Immortal.UI
{
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
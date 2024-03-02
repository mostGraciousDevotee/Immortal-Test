using UnityEngine;
using UnityEditor;
using Immortal.Engine;

namespace Immortal.EngineImplementation
{
    public class UnityApp : IApp
    {
        public void Quit()
        {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
        }
    }
}
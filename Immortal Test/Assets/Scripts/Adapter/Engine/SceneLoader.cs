using System;

using UnityEngine.SceneManagement;
using Immortal.SceneManagement;

namespace Immortal.SceneImplementation
{
    public class SceneLoader : ISceneLoader
    {
        public event Action<string, string> SceneLoaded;

        public SceneLoader()
        {
            SceneManager.activeSceneChanged += OnSceneLoaded;
        }
        
        public void LoadNewGame()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadSavedGame()
        {
            throw new NotImplementedException();
        }

        void OnSceneLoaded(Scene current, Scene next)
        {
            SceneLoaded?.Invoke(current.name, next.name);
        }
    }
}
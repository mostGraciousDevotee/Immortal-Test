using System;
using Immortal.App;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Immortal.Infra
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        public event Action<string, string> SceneLoaded;

        void Awake()
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
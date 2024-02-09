using System;
using Immortal.App;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Immortal.Infra
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        public void LoadNewGame()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadSavedGame()
        {
            throw new NotImplementedException();
        }
    }
}
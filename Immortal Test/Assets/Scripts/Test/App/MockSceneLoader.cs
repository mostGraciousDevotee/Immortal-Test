using System;
using Immortal.SceneManagement;

namespace Immortal.Test
{
    public class MockSceneLoader : ISceneLoader
    {
        internal bool LoadNewGameCalled {get; private set;}

        public event Action<string, string> SceneLoaded;

        public void LoadNewGame()
        {
            LoadNewGameCalled = true;
            SceneLoaded?.Invoke("current", "next");
        }

        public void LoadSavedGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
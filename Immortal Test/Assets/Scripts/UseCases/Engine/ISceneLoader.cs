using System;

namespace Immortal.SceneManagement
{
    public interface ISceneLoader
    {
        event Action<string, string> SceneLoaded;
        void LoadNewGame();
        void LoadSavedGame();
    }
}
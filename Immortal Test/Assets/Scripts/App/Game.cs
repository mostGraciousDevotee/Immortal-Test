using System;

namespace Immortal.App
{
    public class Game : IGame
    {   
        ISceneLoader _sceneLoader;

        public Game(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void NewGame()
        {
            _sceneLoader.LoadNewGame();
        }

        public void Load()
        {

        }
    }

    public interface IGame
    {
        void NewGame();
        void Load();
    }

    public interface ISceneLoader
    {
        void LoadNewGame();
        void LoadSavedGame();
    }
}
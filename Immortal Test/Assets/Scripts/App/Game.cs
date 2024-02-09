using System;
using Immortal.Entities;

namespace Immortal.App
{
    public class Game : IGame
    {   
        ISceneLoader _sceneLoader;
        IFactory _factory;

        public Game(ISceneLoader sceneLoader, IFactory factory)
        {
            _sceneLoader = sceneLoader;
            _factory = factory;
        }
        
        public void NewGame()
        {
            _sceneLoader.LoadNewGame();
        }

        void Run()
        {

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

    public interface IFactory
    {
        ITurnManager GetTurnManager();
    }
}
using System;
using Immortal.Entities;

namespace Immortal.App
{
    public class Game : IGame
    {   
        IFactory _factory;

        public Game(IFactory factory)
        {
            _factory = factory;
        }
        
        public void Run()
        {
            _factory.GetTurnManager().Start();
        }

        public void Load()
        {

        }
    }

    public interface IGame
    {
        void Run();
    }

    public interface ISceneLoader
    {
        event Action<string, string> SceneLoaded;
        void LoadNewGame();
        void LoadSavedGame();
    }

    public interface IFactory
    {
        ITurnManager GetTurnManager();
    }
}
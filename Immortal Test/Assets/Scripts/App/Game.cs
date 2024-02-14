using System;
using Immortal.Entities;

namespace Immortal.App
{
    public class Game : IGame
    {   
        IGameFactory _factory;

        public Game(IGameFactory factory)
        {
            _factory = factory;
        }
        
        public void Run()
        {
            var turnManager = _factory.TurnManager;
            turnManager.AddUnit(_factory.Adam);
            turnManager.AddUnit(_factory.Bruce);
            turnManager.Start();
        }

        public void Load()
        {

        }
    }

    public interface IGame
    {
        void Run();
    }
}
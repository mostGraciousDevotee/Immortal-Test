using Immortal.UnitSystem;
using Immortal.GameSystem;

namespace Immortal.GameImplementation
{
    public class Game : IGame
    {   
        ITurnManager _turnManager;

        public Game
        (
            ITurnManager turnManager
        )
        {
            _turnManager = turnManager;
        }
        
        public void Run()
        {
            _turnManager.Start();
        }
    }
}
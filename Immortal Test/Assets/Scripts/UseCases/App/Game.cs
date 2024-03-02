using Immortal.UnitSystem;
using Immortal.Command;
using Immortal.GameSystem;

namespace Immortal.GameImplementation
{
    public class Game : IGame
    {   
        ITurnManager _turnManager;
        ICommandHistory _commandHistory;

        public Game(ITurnManager turnManager, ICommandHistory commandHistory)
        {
            _turnManager = turnManager;
            _commandHistory = commandHistory;
        }
        
        public void Run()
        {
            _turnManager.Start();
        }

        public void Load()
        {

        }

        public void Undo()
        {
            _commandHistory.Undo();
        }
    }
}
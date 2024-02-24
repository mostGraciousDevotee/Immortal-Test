using Immortal.UnitSystem;

namespace Immortal.App
{
    public abstract class ActionCommand : ICommand
    {
        protected ITurnManager _turnManager;
        protected ActionCommand(ITurnManager turnManager)
        {
            _turnManager = turnManager;
        }
        public abstract void Execute();
        public abstract void Undo();
    }
}
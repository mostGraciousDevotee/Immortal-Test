using Immortal.Command;
using Immortal.Responder;

namespace Immortal.CommandImplementation
{
    public class DisplayRange : ICommand
    {
        ICommandHistory _commandHistory;
        IDisplayRangeResponder _responder;

        public DisplayRange
        (
            ICommandHistory commandHistory,
            IDisplayRangeResponder responder
        )
        {
            _commandHistory = commandHistory;
            _responder = responder;
        }

        public void Execute()
        {
            _responder.Respond();
            _commandHistory.Push(this);
        }

        public void Undo()
        {
            _responder.Unrespond();
        }
    }
}
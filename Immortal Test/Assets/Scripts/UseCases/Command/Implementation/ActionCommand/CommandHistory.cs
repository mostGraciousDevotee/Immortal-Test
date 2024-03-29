using System.Collections.Generic;
using Immortal.Command;

namespace Immortal.CommandImplementation
{
    public class CommandHistory : ICommandHistory
    {
        Stack<ICommand> _commandStack = new Stack<ICommand>();

        public void Push(ICommand command)
        {
            _commandStack.Push(command);
        }

        public void Undo()
        {
            if (_commandStack.Count > 0)
            {
                _commandStack.Pop().Undo();
            }
        }
    }
}
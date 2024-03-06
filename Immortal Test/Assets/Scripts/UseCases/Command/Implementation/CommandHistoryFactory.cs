using Immortal.Generic;

namespace Immortal.CommandImplementation
{
    public class CommandHistoryFactory : IFactory<CommandHistory>
    {
        public CommandHistory Make()
        {
            return new CommandHistory();
        }
    }

    
}
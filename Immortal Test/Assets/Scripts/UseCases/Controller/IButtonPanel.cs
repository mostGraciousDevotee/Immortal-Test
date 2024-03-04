using System.Collections.Generic;
using Immortal.Command;

namespace Immortal.Controller
{
    public interface IButtonPanel
    {
        void Init(List<ICommand> commands);
    }
}
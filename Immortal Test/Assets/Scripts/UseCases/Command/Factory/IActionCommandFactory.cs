using Immortal.Command;

namespace Immortal.CommandFactoryPackage
{
    public interface IActionCommandFactory
    {
        ICommandHistory MakeCommandHistory();
        ICommand MakeEndTurn();
        ICommand MakeDisplayMove();
        ICommand MakeDisplayAttack();
    }
}
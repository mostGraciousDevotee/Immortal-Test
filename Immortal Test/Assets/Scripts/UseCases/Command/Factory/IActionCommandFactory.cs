using Immortal.Command;

namespace Immortal.CommandFactoryPackage
{
    public interface IActionCommandFactory
    {
        ICommand MakeDisplayMove();
        ICommand MakeDisplayAttack();
        ICommand MakeEndTurn();
    }
}
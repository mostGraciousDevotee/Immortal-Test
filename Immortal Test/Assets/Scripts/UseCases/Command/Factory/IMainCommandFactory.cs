using Immortal.Command;

namespace Immortal.CommandFactoryPackage
{
    public interface IMainCommandFactory
    {
        ICommand MakeNewGame();
        ICommand MakeLoadGame();
        ICommand MakeOpenOptions();
        ICommand MakeQuitGame();
    }
}
using Immortal.Command;
using Immortal.SceneManagement;

namespace Immortal.CommandImplementation
{
    public class NewGame : ICommand
    {
        ISceneLoader _sceneLoader;

        public NewGame(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Execute()
        {
            _sceneLoader.LoadNewGame();
        }

        public void Undo()
        {

        }
    }
}
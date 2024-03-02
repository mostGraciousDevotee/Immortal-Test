using Immortal.Command;
using Immortal.CommandFactoryPackage;
using Immortal.Engine;
using Immortal.SceneManagement;

namespace Immortal.CommandImplementation
{
    public class MainCommandFactory : IMainCommandFactory
    {
        ISceneLoader _sceneLoader;
        IApp _app;
        
        public MainCommandFactory(ISceneLoader sceneLoader, IApp app)
        {
            _sceneLoader = sceneLoader;
            _app = app;
        }
        
        public ICommand MakeNewGame()
        {
            return new NewGame(_sceneLoader);
        }

        public ICommand MakeLoadGame()
        {
            throw new System.NotImplementedException();
        }

        public ICommand MakeOpenOptions()
        {
            throw new System.NotImplementedException();
        }

        public ICommand MakeQuitGame()
        {
            return new QuitGame(_app);
        }
    }
}

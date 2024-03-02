using Immortal.Command;
using Immortal.Engine;

namespace Immortal.CommandImplementation
{
    public class QuitGame : ICommand
    {
        IApp _app;
        
        public QuitGame(IApp app)
        {
            _app = app;
        }
        
        public void Execute()
        {
            _app.Quit();
        }

        public void Undo()
        {
            
        }
    }
}
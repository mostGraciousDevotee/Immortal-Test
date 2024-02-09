using Immortal.App;

namespace Immortal.Test
{
    public class MockSceneLoader : ISceneLoader
    {
        internal bool LoadNewGameCalled {get; private set;}
        
        public void LoadNewGame()
        {
            LoadNewGameCalled = true;
        }

        public void LoadSavedGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
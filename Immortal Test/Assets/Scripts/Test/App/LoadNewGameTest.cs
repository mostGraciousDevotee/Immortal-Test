using Immortal.App;

namespace Immortal.Test
{
    public class LoadNewGameTest : BaseTest
    {

        public override bool Test()
        {
            var gameFactory = new GameFactory();
            var game = new Game(gameFactory);

            // return Assert.AreEqual<bool>(true, sceneLoader.LoadNewGameCalled, this.ErrorMessage);
            return false;
        }
    }
}

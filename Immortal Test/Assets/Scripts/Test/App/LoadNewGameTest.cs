using Immortal.App;
using Immortal.Infra;

namespace Immortal.Test
{
    public class LoadNewGameTest : BaseTest
    {

        public override bool Test()
        {
            var sceneLoader = new MockSceneLoader();
            var gameFactory = new GameFactory();
            var game = new Game(sceneLoader, gameFactory);
            game.NewGame();

            return Assert.AreEqual<bool>(true, sceneLoader.LoadNewGameCalled, this.ErrorMessage);
        }
    }
}

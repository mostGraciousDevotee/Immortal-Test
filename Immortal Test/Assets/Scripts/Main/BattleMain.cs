using Immortal.App;
using UnityEngine;

public class BattleMain : MonoBehaviour
{
    IGame _game;
    GameFactory _mainFactory;

    void Awake()
    {
        // TODO: When Factory become so big cache it in GameManager
        _mainFactory = new GameFactory();
        _game = new Game(_mainFactory);
        _game.Run();
    }
}

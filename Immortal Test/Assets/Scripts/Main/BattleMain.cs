using UnityEngine;
using Immortal.App;
using Immortal.UI;
using Immortal.View;
using Immortal.Factory;

namespace Immortal.Main
{
    public class BattleMain : MonoBehaviour
    {
        IGameFactory _gameFactory;
        IButtonBuilder _buttonBuilder;
        [SerializeField] Marker _marker;
        IGame _game;

        void Awake()
        {   
            // TODO: When Factory become so big cache it in GameManager
            _gameFactory = new GameFactory();

            _buttonBuilder = GetComponent<ButtonBuilder>();
            _buttonBuilder.Initialize(_gameFactory);

            var unitPresenters = GetComponent<UnitPresenters>();

            _game = new Game(_gameFactory, _marker, unitPresenters);
        }

        void Start()
        {
            _game.Run();
        }
    }
}
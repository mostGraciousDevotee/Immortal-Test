using UnityEngine;
using Immortal.App;
using Immortal.View;
using Immortal.Factory;

namespace Immortal.Main
{
    public class BattleMain : MonoBehaviour
    {
        IGameFactory _gameFactory;
        IButtonBuilder _buttonBuilder;
        UnitPresenters _unitPresenters;
        [SerializeField] Marker _marker;
        IGame _game;

        void Awake()
        {
            SetUpFactory();
            SetUpGame();
            SetUpButtons();
        }

        void SetUpFactory()
        {
            // TODO: When Factory become so big cache it in GameManager
            _gameFactory = new GameFactory();
            _unitPresenters = GetComponent<UnitPresenters>();
            _buttonBuilder = GetComponent<ButtonBuilder>();
        }

        private void SetUpGame()
        {
            _game = new Game(_gameFactory, _marker, _unitPresenters);
        }

        void SetUpButtons()
        {
            _buttonBuilder.Initialize(_gameFactory);
        }

        void Start()
        {
            _game.Run();
        }
    }
}
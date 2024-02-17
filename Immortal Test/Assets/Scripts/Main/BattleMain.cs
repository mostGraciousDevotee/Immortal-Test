using UnityEngine;
using Immortal.App;
using Immortal.View;
using Immortal.Factory;

namespace Immortal.Main
{
    public class BattleMain : MonoBehaviour
    {
        IRepository _repository;
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
            var gameFactory = new GameFactory();
            _repository = new Repository(gameFactory);
            _unitPresenters = GetComponent<UnitPresenters>();
            _buttonBuilder = GetComponent<ButtonBuilder>();
        }

        private void SetUpGame()
        {
            _game = new Game(_repository, _marker, _unitPresenters);
        }

        void SetUpButtons()
        {
            _buttonBuilder.Initialize(_repository);
        }

        void Start()
        {
            _game.Run();
        }
    }
}
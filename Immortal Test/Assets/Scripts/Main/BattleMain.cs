using UnityEngine;
using Immortal.App;
using Immortal.View;
using Immortal.Factory;
using Immortal.UI;
using Immortal.UnitImplementation;

namespace Immortal.Main
{
    [RequireComponent(typeof(Mouse))]
    public class BattleMain : MonoBehaviour
    {
        IRepository _repository;
        IButtonBuilder _buttonBuilder;
        UnitPresenters _unitPresenters;
        [SerializeField] Marker _marker;
        IGame _game;
        IMouse _mouse;

        void Awake()
        {
            SetUpFactory();
            SetUpGame();
            SetUpButtons();

            _mouse = GetComponent<Mouse>();
            _mouse.RightMouseButtonDown += HandleRightClick;
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
            _buttonBuilder.Build(_repository);
        }

        void Start()
        {
            _game.Run();
        }

        void HandleRightClick()
        {
            _game.Undo();
        }
    }
}
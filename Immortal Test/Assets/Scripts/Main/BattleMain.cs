using UnityEngine;

using Immortal.GameImplementation;

using Immortal.UnitFactoryPackage;
using Immortal.UnitImplementation;

using Immortal.CellFactoryPackage;
using Immortal.CellImplementation;

using Immortal.CommandFactoryPackage;
using Immortal.CommandImplementation;

using Immortal.Controller;
using Immortal.ControllerImplementation;

using Immortal.PresenterImplementation;
using Immortal.PresenterFactory;
using Immortal.GameSystem;

namespace Immortal.Main
{
    [RequireComponent(typeof(Mouse))]
    [RequireComponent(typeof(PresenterContainer))]
    public class BattleMain : MonoBehaviour
    {
        ActionButtons _actionButtons;
        IMouse _mouse;

        IUnitPresenters _unitPresenters;
        [SerializeField] Marker _marker;
        IGame _game;
        
        IUnitFactory _unitFactory;
        ICellFactory _cellFactory;
        ICellDisplayContainer _cellDisplayContainer;
        IActionCommandFactory _commandFactory;

        void Awake()
        {   
            _mouse = GetComponent<Mouse>();
            _mouse.RightMouseButtonDown += HandleRightClick;

            SetUpFactory();
            
            SetUpButtons();

            SetUpGame();
        }

        void SetUpFactory()
        {
            _unitFactory = new UnitFactory();
            _cellFactory = new CellFactory();

            _cellDisplayContainer = GetComponent<PresenterContainer>();
            _cellDisplayContainer.Init(_cellFactory.GetSquareCells().CellSize);

            _commandFactory = new ActionCommandFactory
            (
                _unitFactory,
                _cellFactory,
                _cellDisplayContainer
            );

            _unitPresenters = GetComponent<UnitPresenters>();
            _actionButtons = GetComponent<ActionButtons>();
        }

        private void SetUpGame()
        {
            var gameBuilder = new GameBuilder
            (
                _unitFactory,
                _unitPresenters,
                _marker,
                _cellFactory,
                _commandFactory
            );

            _game = gameBuilder.MakeGame();
        }

        void SetUpButtons()
        {
            if (_commandFactory == null)
            {
                Debug.LogError("Command Factory is null!");
            }

            _actionButtons.Init(_commandFactory);
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
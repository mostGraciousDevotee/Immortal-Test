using UnityEngine;

using Immortal.GlobalFactory;

using Immortal.GameImplementation;

using Immortal.UnitFactoryPackage;

using Immortal.CellFactoryPackage;

using Immortal.CommandFactoryPackage;
using Immortal.CommandImplementation;

using Immortal.Controller;
using Immortal.ControllerImplementation;

using Immortal.PresenterImplementation;
using Immortal.PresenterFactory;
using Immortal.GameSystem;

namespace Immortal.Main
{
    [RequireComponent(typeof(IMouse))]
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
            _mouse = GetComponent<IMouse>();
            _mouse.RightMouseButtonDown += HandleRightClick;

            SetUpFactory();
            
            SetUpButtons();

            SetUpGame();
        }

        void SetUpFactory()
        {
            _unitFactory = GGFactory<IUnitFactory>.Instance;
            _cellFactory = GGFactory<ICellFactory>.Instance;

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
using UnityEngine;

using Immortal.UnitFactoryPackage;

using Immortal.CellFactoryPackage;

using Immortal.Command;
using Immortal.CommandFactoryPackage;

using Immortal.Controller;

using Immortal.PresenterImplementation;
using Immortal.PresenterFactory;
using Immortal.GameSystem;
using Immortal.GenericGlobal;
using Immortal.GameFactory;
using System.Collections.Generic;
using Immortal.ResponderFactory;
using System;
using Immortal.Responder;

namespace Immortal.Main
{
    [RequireComponent(typeof(IMouse))]
    public class BattleMain : MonoBehaviour
    {
        IUnitPresenters _unitPresenters;
        [SerializeField] Marker _marker;
        IGame _game;

        // Undo UseCase
        IMouse _mouse;
        ICommandHistory _commandHistory;

        // Display Range Use Case
        IPresenterContainer _presenterContainer;
        IDisplayRangeResponder _moveResponder;
        IDisplayRangeResponder _attackResponder;

        void Start()
        {
            BindResponder();
            BindUndoController();
            SetUpActionButtons();

            SetUpFactory();
            _game.Run();
        }

        void OnDestroy()
        {
            UnbindResponder();
            UnbindUndoController();
        }

        void BindUndoController()
        {
            _mouse = GetComponent<IMouse>();
            _commandHistory = Singleton<ICommandHistory>.Instance;

            _mouse.RightMouseButtonDown += _commandHistory.Undo;
        }

        void UnbindUndoController()
        {
            _mouse.RightMouseButtonDown -= _commandHistory.Undo;
        }

        void SetUpFactory()
        {
            _unitPresenters = GetComponent<UnitPresenters>();

            _game = Singleton<IGame>.Instance;

            // Binding Unit Presenters and Marker
            var gameBuilder = Singleton<IGameBuilder>.Instance;
            gameBuilder.Build(_game, _unitPresenters, _marker);
        }

        void BindResponder()
        {
            InitPresenterContainer();
            InitResponder();

            BindResponder(_moveResponder);
            BindResponder(_attackResponder);
        }

        void InitResponder()
        {
            var responderFactory = Singleton<IDisplayRangeResponderFactory>.Instance;
            _moveResponder = responderFactory.MakeDisplayMoveResponder();
            _attackResponder = responderFactory.MakeDisplayAttackResponder();
        }

        void InitPresenterContainer()
        {
            _presenterContainer = GetComponent<IPresenterContainer>();
        }

        void BindResponder(IDisplayRangeResponder responder)
        {
            responder.ShowValidRange += _presenterContainer.CellDisplays.Show;
            responder.ShowValidRange += (a, b, c) => _presenterContainer.ActionPanel.Hide();

            responder.Unshow += _presenterContainer.CellDisplays.Hide;
            responder.Unshow += _presenterContainer.ActionPanel.Show;
        }

        void UnbindResponder()
        {
            UnbindResponder(_moveResponder);
            UnbindResponder(_attackResponder);
        }

        void UnbindResponder(IDisplayRangeResponder responder)
        {
            responder.ShowValidRange -= _presenterContainer.CellDisplays.Show;
            responder.ShowValidRange -= (a, b, c) => _presenterContainer.ActionPanel.Hide();

            responder.Unshow -= _presenterContainer.CellDisplays.Hide;
            responder.Unshow -= _presenterContainer.ActionPanel.Show;
        }

        void SetUpActionButtons()
        {
            var commandFactory = Singleton<IActionCommandFactory>.Instance;
            
            if (commandFactory == null)
            {
                Debug.LogError("Command Factory is null!");
            }

            var buttonPanel = GetComponent<IButtonPanel>();
            
            var displayMove = commandFactory.MakeDisplayMove();
            var displayAttack = commandFactory.MakeDisplayAttack();
            var endTurn = commandFactory.MakeEndTurn();

            var commands = new List<ICommand>();

            commands.Add(displayMove);
            commands.Add(displayAttack);
            commands.Add(endTurn);

            buttonPanel.Init(commands);
        }
    }
}
using UnityEngine;

using Immortal.GenericGlobal;

using Immortal.CommandFactoryPackage;
using Immortal.CommandImplementation;

using Immortal.UnitImplementation;

using Immortal.CellFactoryPackage;
using Immortal.CellImplementation;

using Immortal.EngineImplementation;
using Immortal.SceneImplementation;

using Immortal.PresenterFactory;

using Immortal.GameSystem;
using Immortal.GameImplementation;
using Immortal.GameFactory;

using Immortal.ResponderImpl;
using Immortal.Responder;
using Immortal.Generic;
using Immortal.ResponderFactory;
using Immortal.Command;

namespace Immortal.Main
{
    public class Main : MonoBehaviour
    {
        void Awake()
        {
            InitMainCommandFactory();

            InitActionCommandFactory();
        }

        void InitMainCommandFactory()
        {
            var sceneLoader = new SceneLoader();
            var unityApp = new UnityApp();

            Singleton<IMainCommandFactory>.Instance = new MainCommandFactory(sceneLoader, unityApp);
        }

        void InitActionCommandFactory()
        {
            var unitFactory = new UnitFactory();
            var cellFactory = new CellFactory();
            var cellDisplayContainer = GetComponent<ICellDisplayPrefabs>();

            var displayRangeResponderFactory = new DisplayRangeResponderFactory
            (
                unitFactory.MakeTurnManager(),
                cellFactory.GetSquareCells(),
                cellFactory.GetValidMoveProvider(),
                cellFactory.GetValidAttackProvider()
            );

            var commandHistory = new CommandHistory();

            Singleton<ICommandHistory>.Instance = commandHistory;

            var game = new Game
            (
                unitFactory.MakeTurnManager()
            );

            var actionCommandFactory = new ActionCommandFactory
            (
                unitFactory,
                displayRangeResponderFactory,
                commandHistory
            );

            Singleton<IDisplayRangeResponderFactory>.Instance = displayRangeResponderFactory;
            Singleton<IActionCommandFactory>.Instance = actionCommandFactory;

            // TODO : IGame should have an event
            // DisplayMoveCells
            // DisplayAttackCells
            var gameBuilder = new GameBuilder
            (
                unitFactory,
                cellFactory,
                commandHistory
            );

            Singleton<ICellFactory>.Instance = cellFactory;
            Singleton<IGameBuilder>.Instance = gameBuilder;
            Singleton<IGame>.Instance = game;
        }
    }
}
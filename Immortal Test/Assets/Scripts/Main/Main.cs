using UnityEngine;

using Immortal.GenericGlobal;

using Immortal.CommandFactoryPackage;
using Immortal.CommandImplementation;

using Immortal.UnitImplementation;
using Immortal.UnitFactoryPackage;

using Immortal.CellFactoryPackage;
using Immortal.CellImplementation;

using Immortal.EngineImplementation;
using Immortal.SceneImplementation;

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
        // BattleSceneDependencies
        IUnitFactory _unitFactory;
        ICellFactory _cellFactory;
        IDisplayRangeResponderFactory _displayRangeResponderFactory;
        ICommandHistory _commandHistory;
        
        void Awake()
        {
            BuildMainSceneDependencies();
            BuildBattleSceneDependencies();
        }

        void BuildBattleSceneDependencies()
        {
            CreateUnitFactory();
            CreateCellFactory();
            CreateDisplayRangeResponderFactory();
            CreateCommandHistory();

            // DisplayRange
            InitDisplayRangeResponderFactory();
            InitCommandHistory();
            InitActionCommandFactory();

            // UnitPosition
            InitCellFactory();
            InitGameBuilder();
            InitGame();
        }

        void BuildMainSceneDependencies()
        {
            var sceneLoader = new SceneLoader();
            var unityApp = new UnityApp();

            Singleton<IMainCommandFactory>.Instance = new MainCommandFactory(sceneLoader, unityApp);
        }

        void InitActionCommandFactory()
        {
            var actionCommandFactory = new ActionCommandFactory
            (
                _unitFactory,
                _displayRangeResponderFactory,
                _commandHistory
            );
            Singleton<IActionCommandFactory>.Instance = actionCommandFactory;
        }

        void InitDisplayRangeResponderFactory()
        {
            Singleton<IDisplayRangeResponderFactory>.Instance = _displayRangeResponderFactory;
        }

        void CreateUnitFactory()
        {
            _unitFactory = new UnitFactory();
        }

        void CreateCellFactory()
        {
            _cellFactory = new CellFactory();
        }

        void CreateDisplayRangeResponderFactory()
        {
            _displayRangeResponderFactory = new DisplayRangeResponderFactory
            (
                _unitFactory.MakeTurnManager(),
                _cellFactory.GetSquareCells(),
                _cellFactory.GetValidMoveProvider(),
                _cellFactory.GetValidAttackProvider()
            );
        }

        void CreateCommandHistory()
        {
            _commandHistory = new CommandHistory();
        }

        void InitCellFactory()
        {
            Singleton<ICellFactory>.Instance = _cellFactory;
        }

        void InitCommandHistory()
        {
            Singleton<ICommandHistory>.Instance = _commandHistory;
        }

        void InitGameBuilder()
        {
            var gameBuilder = new GameBuilder
            (
                _unitFactory,
                _cellFactory,
                _commandHistory
            );

            Singleton<IGameBuilder>.Instance = gameBuilder;
        }

        void InitGame()
        {
            var game = new Game
            (
                _unitFactory.MakeTurnManager()
            );

            Singleton<IGame>.Instance = game;
        }
    }
}
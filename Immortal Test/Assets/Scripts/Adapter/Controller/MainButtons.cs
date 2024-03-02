using UnityEngine;
using Immortal.CommandFactoryPackage;

namespace Immortal.ControllerImplementation
{
    public class MainButtons : MonoBehaviour
    {
        [SerializeField] ButtonHandler _newGameHandler;
        [SerializeField] ButtonHandler _loadGameHandler;
        [SerializeField] ButtonHandler _openOptionsHandler;
        [SerializeField] ButtonHandler _quitGameHandler;

        IMainCommandFactory _commandFactory;

        public void Init(IMainCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;

            InitNewGameButton();
            InitExitGameHandler();
        }

        void InitNewGameButton()
        {
            _newGameHandler.Command = _commandFactory.MakeNewGame();
        }

        void InitLoadGameButton()
        {
            _loadGameHandler.Command = _commandFactory.MakeLoadGame();
        }

        void InitOpenOptionsButton()
        {
            _openOptionsHandler.Command = _commandFactory.MakeOpenOptions();
        }

        void InitExitGameHandler()
        {
            _quitGameHandler.Command = _commandFactory.MakeQuitGame();
        }
    }
}
using UnityEngine;
using System.Collections.Generic;

using Immortal.CommandFactoryPackage;
using Immortal.Command;
using Immortal.Controller;
using Immortal.GenericGlobal;

namespace Immortal.Main
{
    public class MainSceneBuilder : MonoBehaviour
    {
        IButtonPanel _buttonPanel;

        void Start()
        {
            InitMainButtonPanel();
        }

        void InitMainButtonPanel()
        {
            _buttonPanel = GetComponent<IButtonPanel>();

            var commands = new List<ICommand>();

            // TODO : Implement LoadGame button and Option button!
            var mainCommandFactory = Singleton<IMainCommandFactory>.Instance;

            var newGame = mainCommandFactory.MakeNewGame();
            var loadGame = newGame;
            var options = newGame;
            var quitGame = mainCommandFactory.MakeQuitGame();

            commands.Add(newGame);
            commands.Add(loadGame);
            commands.Add(options);
            commands.Add(quitGame);

            _buttonPanel.Init(commands);
        }
    }
}
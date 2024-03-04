using UnityEngine;
using System.Collections.Generic;

using Immortal.GlobalFactory;
using Immortal.CommandFactoryPackage;
using Immortal.Command;
using Immortal.Controller;

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
            var mainCommandFactory = GGFactory<IMainCommandFactory>.Instance;

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
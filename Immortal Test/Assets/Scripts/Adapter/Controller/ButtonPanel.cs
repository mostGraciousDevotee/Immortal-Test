using System.Collections.Generic;
using Immortal.Command;
using Immortal.Controller;
using UnityEngine;

namespace Immortal.ControllerImplementation
{
    public class ButtonPanel : MonoBehaviour, IButtonPanel
    {
        [SerializeField] List<ButtonHandler> _buttonHandlers;
        List<ICommand> _commands;
        
        public void Init(List<ICommand> commands)
        {
            _commands = commands;
            if (_commands != null && _commands.Count == _buttonHandlers.Count)
            {
                int i = 0;
                foreach (ICommand command in _commands)
                {
                    _buttonHandlers[i++].Command = command;
                }
            }
            else
            {
                Debug.LogError("Failed to initialize " + gameObject.name);
            }
        }
    }
}
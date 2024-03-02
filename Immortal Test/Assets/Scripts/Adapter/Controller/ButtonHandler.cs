using Immortal.Command;
using UnityEngine;
using UnityEngine.UI;

namespace Immortal.ControllerImplementation
{
    // TODO : If no other package beside main called the ICommandInvoker
    // ICommandInvoker should be deleted.
    public class ButtonHandler : MonoBehaviour, ICommandInvoker
    {
        Button _button;
        ICommand _command;

        void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        void OnButtonClicked()
        {
            _command?.Execute();
        }

        public ICommand Command
        {
            set => _command = value;
        }
    }
}
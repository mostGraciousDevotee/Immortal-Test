using UnityEngine;
using UnityEngine.UI;
using Immortal.App;

namespace Immortal.Infra.UI
{
    public class UIButton : MonoBehaviour, IButton
    {
        [SerializeField] Button _button;
        ICommand _command;

        void Awake()
        {
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
            get => _command;
            set => _command = value;
        }
    }
}
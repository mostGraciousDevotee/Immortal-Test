using System;
using UnityEngine;
using UnityEngine.UI;

namespace Immortal.UI
{
    // TODO : Refactor this to ButtonUI
    public class MainPanel : MonoBehaviour
    {
        [SerializeField] Button _newButton;
        [SerializeField] Button _quitButton;
        
        public event Action NewButtonPressed;
        public event Action QuitButtonPressed;

        void Awake()
        {
            _newButton.onClick.AddListener(OnNewButtonPressed);
            _quitButton.onClick.AddListener(OnQuitButtonPressed);
        }

        void OnDestroy()
        {
            _newButton.onClick.RemoveAllListeners();
            _quitButton.onClick.RemoveAllListeners();
        }

        void OnNewButtonPressed()
        {
            NewButtonPressed?.Invoke();
        }

        void OnQuitButtonPressed()
        {
            QuitButtonPressed?.Invoke();
        }
    }
}
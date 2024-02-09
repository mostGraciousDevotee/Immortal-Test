using Immortal.Infra;
using Immortal.UI;
using UnityEditor;
using UnityEngine;

namespace Immortal.Main
{
    public class Main : MonoBehaviour
    {
        [SerializeField] MainPanel _mainPanel;
        SceneLoader _sceneLoader;
        
        
        void Awake()
        {   
            _sceneLoader = GetComponent<SceneLoader>();
            
            _mainPanel.NewButtonPressed += NewGame;
            _mainPanel.QuitButtonPressed += Quit;
        }

        void NewGame()
        {
            _mainPanel.NewButtonPressed -= NewGame;
            _mainPanel.QuitButtonPressed -= Quit;

            _sceneLoader.LoadNewGame();
        }
        
        void Quit()
        {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
        }
    }
}
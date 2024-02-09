using Immortal.App;
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
        
        IGame _game;
        GameFactory _mainFactory;
        
        void Awake()
        {
            DontDestroyOnLoad(this);
            
            _sceneLoader = GetComponent<SceneLoader>();

            _mainFactory = new GameFactory();
            _game = new Game(_sceneLoader, _mainFactory);
            
            _mainPanel.NewButtonPressed += NewGame;
            _mainPanel.QuitButtonPressed += Quit;
        }

        void NewGame()
        {
            _mainPanel.NewButtonPressed -= NewGame;
            _mainPanel.QuitButtonPressed -= Quit;

            _game.NewGame();
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
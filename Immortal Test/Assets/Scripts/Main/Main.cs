using UnityEngine;

using Immortal.ControllerImplementation;
using Immortal.CommandImplementation;
using Immortal.SceneImplementation;
using Immortal.EngineImplementation;
using Immortal.SceneManagement;
using Immortal.Engine;

namespace Immortal.Main
{
    // TODO : Create IMain for testing
    public class Main : MonoBehaviour
    {
        [SerializeField] MainButtons _mainButtons;
        ISceneLoader _sceneLoader;
        IApp _unityApp;
        
        void Awake()
        {   
            var sceneLoader = new SceneLoader();
            var app = new UnityApp();

            var mainCommandFactory = new MainCommandFactory(sceneLoader, app);

            _mainButtons.Init(mainCommandFactory);
        }

        void InitButtons()
        {

        }
    }
}
using UnityEngine;

using Immortal.GlobalFactory;

using Immortal.CommandFactoryPackage;
using Immortal.CommandImplementation;

using Immortal.UnitFactoryPackage;
using Immortal.UnitImplementation;

using Immortal.CellFactoryPackage;
using Immortal.CellImplementation;

using Immortal.EngineImplementation;
using Immortal.SceneImplementation;

namespace Immortal.Main
{
    public class Main : MonoBehaviour
    {
        void Awake()
        {
            var sceneLoader = new SceneLoader();
            var unityApp = new UnityApp();

            GGFactory<IMainCommandFactory>.Instance =
                new MainCommandFactory(sceneLoader, unityApp);

            GGFactory<IUnitFactory>.Instance =
                new UnitFactory();

            GGFactory<ICellFactory>.Instance =
                new CellFactory();
        }
    }
}
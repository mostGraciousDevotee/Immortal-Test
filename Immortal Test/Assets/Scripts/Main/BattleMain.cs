using Immortal.App;
using Immortal.Infra.UI;
using Immortal.Infra.View;
using UnityEngine;

namespace Immortal.Main
{
    public class BattleMain : MonoBehaviour
    {
        IGame _game;
        IGameFactory _mainFactory;
        IButtonBuilder _uiFactory;
        [SerializeField] Marker _marker;

        void Awake()
        {   
            // TODO: When Factory become so big cache it in GameManager
            _mainFactory = new GameFactory();

            _uiFactory = GetComponent<ButtonBuilder>();
            _uiFactory.Initialize(_mainFactory);

            var unitViews = GetComponent<UnitViews>();

            _game = new Game(_mainFactory, _marker, unitViews);
            _game.Run();
        }
    }
}


using Immortal.App;
using UnityEngine;

namespace Immortal.Infra.UI
{
    public class ButtonBuilder : MonoBehaviour, IButtonBuilder
    {
        [SerializeField] UIButton _endTurnButton;
        IGameFactory _gameFactory;

        public void Initialize(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            BuildEndTurnButton();
        }

        void BuildEndTurnButton()
        {
            var endTurn = new EndTurn(_gameFactory.TurnManager);
            _endTurnButton.Command = endTurn;
        }

        public IButton EndTurnButton => _endTurnButton;
    }
}
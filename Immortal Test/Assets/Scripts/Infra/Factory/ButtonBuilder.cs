using UnityEngine;
using Immortal.App;
using Immortal.UI;

namespace Immortal.Factory
{
    public class ButtonBuilder : MonoBehaviour, IButtonBuilder
    {
        [SerializeField] ButtonHandler _endTurnButtonHandler;
        IGameFactory _gameFactory;

        public void Initialize(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            BuildEndTurnButton();
        }

        void BuildEndTurnButton()
        {
            var endTurn = new EndTurn(_gameFactory.TurnManager);
            _endTurnButtonHandler.Command = endTurn;
        }
    }
}
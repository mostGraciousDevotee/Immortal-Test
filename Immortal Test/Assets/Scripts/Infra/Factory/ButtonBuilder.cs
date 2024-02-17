using UnityEngine;
using Immortal.App;
using Immortal.UI;

namespace Immortal.Factory
{
    public class ButtonBuilder : MonoBehaviour, IButtonBuilder
    {
        [SerializeField] ButtonHandler _endTurnButtonHandler;
        IRepository _repository;

        public void Initialize(IRepository repository)
        {
            _repository = repository;
            BuildEndTurnButton();
        }

        void BuildEndTurnButton()
        {
            var endTurn = new EndTurn(_repository.TurnManager);
            _endTurnButtonHandler.Command = endTurn;
        }
    }
}
using UnityEngine;
using Immortal.App;
using Immortal.UI;
using Immortal.View;

namespace Immortal.Factory
{
    public class ButtonBuilder : MonoBehaviour, IButtonBuilder
    {
        [SerializeField] Panel _actionPanel;
        [SerializeField] ButtonHandler _moveButtonHandler;
        [SerializeField] ButtonHandler _endTurnButtonHandler;

        IRepository _repository;

        [SerializeField] CellDisplay _moveDisplay;
        [SerializeField] CellDisplays _cellDisplays;

        public void Initialize(IRepository repository)
        {
            _repository = repository;

            _cellDisplays.Init(_repository.SquareCells.CellSize);

            BuildMoveButton();
            BuildEndTurnButton();
        }

        void BuildEndTurnButton()
        {
            var endTurn = new EndTurn(_repository.TurnManager);
            _endTurnButtonHandler.Command = endTurn;
        }

        void BuildMoveButton()
        {
            var displayMove = new DisplayMovement
            (
                _repository.TurnManager,
                _repository.MovementValidator,
                _cellDisplays,
                _moveDisplay,
                _actionPanel,
                _repository.CommandHistory
            );
            _moveButtonHandler.Command = displayMove;
        }
    }
}
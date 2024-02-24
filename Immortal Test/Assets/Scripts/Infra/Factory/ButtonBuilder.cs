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
        [SerializeField] ButtonHandler _attackButtonHandler;
        [SerializeField] ButtonHandler _endTurnButtonHandler;

        IRepository _repository;

        [SerializeField] CellDisplays _cellDisplays;
        [SerializeField] CellDisplay _moveDisplay;
        [SerializeField] CellDisplay _attackDisplay;

        public void Build(IRepository repository)
        {
            _repository = repository;

            _cellDisplays.Init(_repository.SquareCells.CellSize);

            BuildMoveButton();
            BuildAttackButton();
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
                _repository.CommandHistory,
                _repository.MovementValidator,
                _cellDisplays,
                _moveDisplay,
                _actionPanel
            );

            _moveButtonHandler.Command = displayMove;
        }

        void BuildAttackButton()
        {
            var displayAttack = new DisplayAttack
            (
                _repository.TurnManager,
                _repository.CommandHistory,
                _repository.AttackValidator,
                _cellDisplays,
                _attackDisplay,
                _actionPanel
            );

            _attackButtonHandler.Command = displayAttack;
        }
    }
}
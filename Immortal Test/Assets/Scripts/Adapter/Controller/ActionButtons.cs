using UnityEngine;

using Immortal.CommandFactoryPackage;

namespace Immortal.ControllerImplementation
{
    public class ActionButtons : MonoBehaviour
    {
        [SerializeField] ButtonHandler _moveButtonHandler;
        [SerializeField] ButtonHandler _attackButtonHandler;
        [SerializeField] ButtonHandler _endTurnButtonHandler;

        IActionCommandFactory _commandFactory;

        public void Init(IActionCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;

            InitMoveButton();
            InitAttackButton();
            InitEndTurnButton();
        }

        void InitEndTurnButton()
        {
            _endTurnButtonHandler.Command = _commandFactory.MakeEndTurn();
        }

        void InitMoveButton()
        {
            _moveButtonHandler.Command = _commandFactory.MakeDisplayMove();
        }

        void InitAttackButton()
        {
            _attackButtonHandler.Command = _commandFactory.MakeDisplayAttack();
        }
    }
}
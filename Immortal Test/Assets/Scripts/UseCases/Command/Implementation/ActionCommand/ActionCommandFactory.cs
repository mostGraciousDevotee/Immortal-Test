using Immortal.Command;
using Immortal.CommandFactoryPackage;

using Immortal.UnitFactoryPackage;
using Immortal.CellFactoryPackage;
using Immortal.PresenterFactory;

namespace Immortal.CommandImplementation
{
    public class ActionCommandFactory : IActionCommandFactory
    {   
        IUnitFactory _unitFactory;
        ICellFactory _cellFactory;
        ICellDisplayContainer _cellDisplayContainer;

        ICommandHistory _commandHistory;
        ICommand _displayMove;
        ICommand _displayAttack;
        ICommand _endTurn;

        public ActionCommandFactory
        (
            IUnitFactory unitFactory,
            ICellFactory cellFactory,
            ICellDisplayContainer cellDisplayContainer
        )
        {
            _unitFactory = unitFactory;
            _cellFactory = cellFactory;
            _cellDisplayContainer = cellDisplayContainer;
        }

        // TODO : This should be made private
        public ICommandHistory MakeCommandHistory()
        {
            if (_commandHistory == null)
            {
                _commandHistory = new CommandHistory();
            }

            return _commandHistory;
        }

        public ICommand MakeDisplayAttack()
        {
            if (_displayAttack == null)
            {
                _displayAttack = new DisplayAttack
                (
                    _unitFactory.MakeTurnManager(),
                    MakeCommandHistory(),
                    _cellFactory.GetValidAttackProvider(),
                    _cellDisplayContainer.CellDisplays,
                    _cellDisplayContainer.AttackDisplayPrefab,
                    _cellDisplayContainer.ActionPanel
                );
            }

            return _displayAttack;
        }

        public ICommand MakeDisplayMove()
        {
            if (_displayMove == null)
            {
                _displayMove = new DisplayMovement
                (
                    _unitFactory.MakeTurnManager(),
                    MakeCommandHistory(),
                    _cellFactory.GetValidMoveProvider(),
                    _cellDisplayContainer.CellDisplays,
                    _cellDisplayContainer.MoveDisplayPrefab,
                    _cellDisplayContainer.ActionPanel
                );
            }

            return _displayMove;
        }

        public ICommand MakeEndTurn()
        {
            if (_endTurn == null)
            {
                _endTurn = new EndTurn(_unitFactory.MakeTurnManager());
            }

            return _endTurn;
        }
    }
}
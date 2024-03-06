using Immortal.Command;
using Immortal.CommandFactoryPackage;

using Immortal.UnitFactoryPackage;

using Immortal.GameSystem;
using Immortal.Responder;
using Immortal.ResponderFactory;

namespace Immortal.CommandImplementation
{
    public class ActionCommandFactory : IActionCommandFactory
    {   
        IUnitFactory _unitFactory;

        IGame _game;
        IDisplayRangeResponderFactory _responderFactory;
        ICommandHistory _commandHistory;

        ICommand _displayMove;
        ICommand _displayAttack;
        ICommand _endTurn;

        public ActionCommandFactory
        (
            IUnitFactory unitFactory,
            IDisplayRangeResponderFactory responderFactory,
            ICommandHistory commandHistory
        )
        {
            _unitFactory = unitFactory;
            _responderFactory = responderFactory;
            _commandHistory = commandHistory;
        }

        public ICommand MakeDisplayAttack()
        {
            if (_displayAttack == null)
            {
                _displayAttack = new DisplayRange
                (
                    _commandHistory,  // command history
                    _responderFactory.MakeDisplayAttackResponder()
                );
            }

            return _displayAttack;
        }

        public ICommand MakeDisplayMove()
        {
            _displayMove = new DisplayRange
            (
                _commandHistory,
                _responderFactory.MakeDisplayMoveResponder()
            );

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
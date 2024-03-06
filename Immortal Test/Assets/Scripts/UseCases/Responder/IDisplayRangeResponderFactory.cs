using Immortal.Responder;

namespace Immortal.ResponderFactory
{
    public interface IDisplayRangeResponderFactory
    {
        IDisplayRangeResponder MakeDisplayMoveResponder();
        IDisplayRangeResponder MakeDisplayAttackResponder(); 
    }
}
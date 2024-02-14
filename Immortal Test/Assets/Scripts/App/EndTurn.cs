namespace Immortal.App
{
    public class EndTurn : ICommand
    {
        ITurnManager _turnManager;

        public EndTurn(TurnManager turnManager)
        {
            _turnManager = turnManager;
        }
        
        public void Execute()
        {
            _turnManager.EndTurn();
        }
    }
}
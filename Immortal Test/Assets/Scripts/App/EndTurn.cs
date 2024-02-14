namespace Immortal.App
{
    public class EndTurn : ICommand
    {
        ITurnManager _turnManager;

        public EndTurn(ITurnManager turnManager)
        {
            _turnManager = turnManager;
        }
        
        public void Execute()
        {
            _turnManager.EndTurn();
        }
    }
}
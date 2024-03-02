namespace Immortal.Command
{
    public interface ICommandHistory
    {
        void Push(ICommand command);
        void Undo();
    }
}
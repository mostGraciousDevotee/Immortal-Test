namespace Immortal.App
{
    public interface ICommandHistory
    {
        void Push(ICommand command);
        void Undo();
    }
}
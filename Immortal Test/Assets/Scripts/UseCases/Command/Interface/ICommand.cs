namespace Immortal.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
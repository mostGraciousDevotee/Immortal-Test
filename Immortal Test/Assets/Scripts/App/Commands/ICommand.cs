namespace Immortal.App
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
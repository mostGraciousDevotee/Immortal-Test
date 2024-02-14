using System;

namespace Immortal.App
{
    public interface ISceneLoader
    {
        event Action<string, string> SceneLoaded;
        void LoadNewGame();
        void LoadSavedGame();
    }

    public interface IUIFactory
    {
        IButton EndTurnButton { get; }
    }
    
    public interface IButton
    {
        ICommand Command {get; set;}
    }

    public interface ICommand
    {
        void Execute();
    }
}
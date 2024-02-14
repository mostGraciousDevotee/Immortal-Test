using System;
using Immortal.Entities;

namespace Immortal.App
{
    public interface ISceneLoader
    {
        event Action<string, string> SceneLoaded;
        void LoadNewGame();
        void LoadSavedGame();
    }

    public interface IButtonBuilder
    {
        void Initialize(IGameFactory turnManager);
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

    public interface IMarkerHandler
    {
        void Mark(IUnit unit);
    }

    public interface IMarker
    {
        void Mark(IUnitView unitView);
    }
}
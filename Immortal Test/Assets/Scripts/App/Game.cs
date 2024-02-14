using System.Collections.Generic;
using Immortal.Entities;

namespace Immortal.App
{
    public class Game : IGame
    {   
        IGameFactory _factory;
        ITurnManager _turnManager;

        IMarkerHandler _markerHandler;
        IUnitViews _unitViews;
        Dictionary<IUnit, IUnitView> _unitViewDict = new Dictionary<IUnit, IUnitView>();

        public Game(IGameFactory factory, IMarker marker, IUnitViews unitViews)
        {
            _factory = factory;
            _turnManager = _factory.TurnManager;
            _unitViews = unitViews;
            _markerHandler = new MarkerHandler(marker, _unitViewDict);

            BuildTurnManager();            
            LinkUnitViews();
        }

        void LinkUnitViews()
        {
            _unitViewDict.Add(_factory.Adam, _unitViews.Adam);
            _unitViewDict.Add(_factory.Bruce, _unitViews.Bruce);
        }

        void BuildTurnManager()
        {
            _turnManager.AddUnit(_factory.Adam);
            _turnManager.AddUnit(_factory.Bruce);

            _turnManager.UnitActive += _markerHandler.Mark;
        }
        
        public void Run()
        {
            _turnManager.Start();
        }

        public void Load()
        {

        }
    }

    public interface IGame
    {
        void Run();
    }

    public interface IUnitViews
    {
        IUnitView Adam {get; }
        IUnitView Bruce {get; }
    }
    public interface IUnitView
    {

    }
}
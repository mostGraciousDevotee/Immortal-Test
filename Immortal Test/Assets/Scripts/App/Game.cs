using System.Collections.Generic;
using Immortal.Entities;
using UnityEngine;

namespace Immortal.App
{
    public class Game : IGame
    {   
        IRepository _repository;
        ITurnManager _turnManager;
        ISquareCells _squareCells;

        IMarkerHandler _markerHandler;
        IUnitPresenters _unitPresenters;
        Dictionary<IUnit, IUnitPresenter> _unitPresenterDict = new Dictionary<IUnit, IUnitPresenter>();

        public Game(IRepository repository, IMarker marker, IUnitPresenters unitViews)
        {
            _repository = repository;
            _turnManager = _repository.TurnManager;
            _squareCells = _repository.SquareCells;

            _unitPresenters = unitViews;
            _markerHandler = new MarkerHandler(marker, _unitPresenterDict);

            BuildTurnManager();            
            LinkUnitViews();

            PlaceUnits();
        }

        void LinkUnitViews()
        {
            _unitPresenterDict.Add(_repository.Adam, _unitPresenters.Adam);
            _unitPresenterDict.Add(_repository.Bruce, _unitPresenters.Bruce);
        }

        void BuildTurnManager()
        {
            _turnManager.AddUnit(_repository.Adam);
            _turnManager.AddUnit(_repository.Bruce);

            _turnManager.UnitActive += _markerHandler.Mark;
        }

        private void PlaceUnits()
        {
            _squareCells.AddUnit(_repository.Adam);
            _repository.Bruce.Position = Vector2Int.right;
            _squareCells.AddUnit(_repository.Bruce);
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
}
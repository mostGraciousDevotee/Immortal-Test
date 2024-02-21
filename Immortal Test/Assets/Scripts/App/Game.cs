using System.Collections.Generic;
using UnityEngine;
using Immortal.Entities;

namespace Immortal.App
{
    public class Game : IGame
    {   
        IRepository _repository;
        ITurnManager _turnManager;
        ISquareCells _squareCells;
        ICommandHistory _commandHistory;

        IMarkerHandler _markerHandler;
        IUnitPresenters _unitPresenters;
        Dictionary<IUnit, IUnitPresenter> _unitPresenterDict = new Dictionary<IUnit, IUnitPresenter>();

        public Game(IRepository repository, IMarker marker, IUnitPresenters unitViews)
        {
            _repository = repository;
            _turnManager = _repository.TurnManager;
            _squareCells = _repository.SquareCells;
            _commandHistory = _repository.CommandHistory;

            _unitPresenters = unitViews;
            _markerHandler = new MarkerHandler(marker, _unitPresenterDict);

            BuildTurnManager();            
            LinkUnitViews();

            PlaceUnits();
        }

        void LinkUnitViews()
        {
            var adam = _repository.Adam;
            var bruce = _repository.Bruce;

            var adamPresenter = _unitPresenters.Adam;
            var brucePresenter = _unitPresenters.Bruce;

            adamPresenter.Init(_squareCells.CellSize);
            brucePresenter.Init(_squareCells.CellSize);

            adam.PositionChanged += adamPresenter.SetPosition;
            bruce.PositionChanged += brucePresenter.SetPosition;
            
            _unitPresenterDict.Add(adam, adamPresenter);
            _unitPresenterDict.Add(bruce, brucePresenter);
        }

        void BuildTurnManager()
        {
            _turnManager.AddUnit(_repository.Adam);
            _turnManager.AddUnit(_repository.Bruce);

            _turnManager.UnitActive += _markerHandler.Mark;
        }

        private void PlaceUnits()
        {
            var adam = _repository.Adam;
            var bruce = _repository.Bruce;
            
            adam.Position = new Vector2Int(5, 5);
            bruce.Position = new Vector2Int(4, 5);
            
            _squareCells.AddUnit(adam);
            _squareCells.AddUnit(bruce);
        }
        
        public void Run()
        {
            _turnManager.Start();
        }

        public void Load()
        {

        }

        public void Undo()
        {
            _commandHistory.Undo();
        }
    }

    public interface IGame
    {
        void Run();
        void Undo();
    }
}
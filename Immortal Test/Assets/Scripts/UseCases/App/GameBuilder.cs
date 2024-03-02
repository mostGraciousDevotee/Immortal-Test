using UnityEngine;

using Immortal.UnitSystem;
using Immortal.UnitFactoryPackage;

using Immortal.CellSystem;
using Immortal.CellFactoryPackage;

using Immortal.Presenter;
using Immortal.UnitPresenterSystem;
using Immortal.PresenterFactory;

using Immortal.CommandFactoryPackage;
using Immortal.GameSystem;

namespace Immortal.GameImplementation
{
    public class GameBuilder
    {
        IUnit _adam;
        IUnitPresenter _adamPresenter;
        IUnit _bruce;
        IUnitPresenter _brucePresenter;

        ITurnManager _turnManager;

        ISquareCells _squareCells;
        IMarker _marker;
        IActionCommandFactory _commandFactory;
        
        public GameBuilder
        (
            IUnitFactory unitFactory,
            IUnitPresenters unitPresenters,
            IMarker marker,
            ICellFactory cellFactory,
            IActionCommandFactory commandFactory
        )
        {
            _marker = marker;
            _commandFactory = commandFactory;

            _adam = unitFactory.MakeAdam();
            _bruce = unitFactory.MakeBruce();
            _turnManager = unitFactory.MakeTurnManager();

            _adamPresenter = unitPresenters.Adam;
            _brucePresenter = unitPresenters.Bruce;

            _squareCells = cellFactory.GetSquareCells();

            BuildUnits();
            PlaceUnits();
        }

        void BuildUnits()
        {
            _adamPresenter.Init(_adam, _squareCells.CellSize);
            _brucePresenter.Init(_bruce, _squareCells.CellSize);

            _adamPresenter.UnitPresenterActive += _marker.Mark;
            _brucePresenter.UnitPresenterActive += _marker.Mark;
        }

        void PlaceUnits()
        {
            _squareCells.UnitAdded += _turnManager.AddUnit;
            
            _adam.Position = new Vector2Int(5, 5);
            _bruce.Position = new Vector2Int(4, 5);

            _squareCells.AddUnit(_adam);
            _squareCells.AddUnit(_bruce);
        }

        public IGame MakeGame()
        {
            return new Game(_turnManager, _commandFactory.MakeCommandHistory());
        }
    }
}
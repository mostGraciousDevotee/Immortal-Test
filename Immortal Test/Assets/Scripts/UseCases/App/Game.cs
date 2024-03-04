using Immortal.UnitSystem;
using Immortal.Command;
using Immortal.GameSystem;
using System;
using Immortal.CellSystem;
using Immortal.Presenter;
using System.Collections.Generic;
using UnityEngine;

namespace Immortal.GameImplementation
{
    public class Game : IGame
    {   
        ITurnManager _turnManager;
        ICommandHistory _commandHistory;

        IValidCellProvider _moveCellProvider;
        IValidCellProvider _attackCellProvider;

        ICellDisplays _cellDisplays;
        IHideable _actionPanel;

        public Game(ITurnManager turnManager, ICommandHistory commandHistory)
        {
            _turnManager = turnManager;
            _commandHistory = commandHistory;
        }
        
        public void Run()
        {
            _turnManager.Start();
        }

        void DisplayCells(List<Vector2Int> validCells, ICellDisplay prefab)
        {
            _cellDisplays.Show(prefab, validCells);
            _actionPanel.Hide();
        }

        public void Load()
        {

        }

        public void Undo()
        {
            _commandHistory.Undo();
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

using Immortal.CellSystem;

namespace Immortal.CellImplementation
{
    public abstract class ValidCellProvider : IValidCellProvider
    {
        List<Vector2Int> _currentNeighbours = new List<Vector2Int>();
        List<Vector2Int> _visitedCells = new List<Vector2Int>();
        Queue<Vector2Int> _currentNeighboursQueue = new Queue<Vector2Int>();
        Queue<Vector2Int> _nextNeighboursQueue = new Queue<Vector2Int>();

        protected ISquareCells _squareCells;
        protected Vector2Int _currentPos;

        protected ValidCellProvider(ISquareCells squareCells)
        {
            _squareCells = squareCells;
        }

        public List<Vector2Int> GetValidCells(Vector2Int startPos, int range)
        {
            Reset();
            _currentPos = startPos;

            var validCells = new List<Vector2Int>();

            EnqueueCurrentNeighboursOf(_currentPos);
            _visitedCells.Add(_currentPos);

            while (range > 0)
            {
                FindValidCells(validCells);

                CopyNextQueueToCurrent();
                _nextNeighboursQueue.Clear();

                range--;
            }

            return validCells;
        }

        void Reset()
        {
            _visitedCells.Clear();
            _currentNeighboursQueue.Clear();
            _nextNeighboursQueue.Clear();
            _currentNeighbours.Clear();
        }

        void EnqueueCurrentNeighboursOf(Vector2Int currentPos)
        {
            _currentNeighbours = GenerateNeigbours(currentPos);

            foreach (Vector2Int cellVector in _currentNeighbours)
            {
                _currentNeighboursQueue.Enqueue(cellVector);
            }
        }

        List<Vector2Int> GenerateNeigbours(Vector2Int pos)
        {
            var neighbours = new List<Vector2Int>();

            Vector2Int forwardNeighbour = pos + Vector2Int.up;
            Vector2Int leftNeigbour = pos + Vector2Int.left;
            Vector2Int backNeighbour = pos + Vector2Int.down;
            Vector2Int rightNeighbour = pos + Vector2Int.right;

            neighbours.Add(forwardNeighbour);
            neighbours.Add(leftNeigbour);
            neighbours.Add(backNeighbour);
            neighbours.Add(rightNeighbour);

            return neighbours;
        }

        void FindValidCells(List<Vector2Int> traversableCells)
        {
            while (_currentNeighboursQueue.Count > 0)
            {
                if (_currentNeighboursQueue.Count > 100)
                {
                    throw new Exception("Finding traversable cells exceeded 100 iterations");
                }

                _currentPos = _currentNeighboursQueue.Dequeue();
                EnqueueNextNeighbours(_currentPos);

                bool isInsideCells = _squareCells.IsInside(_currentPos);
                bool isVisited = _visitedCells.Contains(_currentPos);

                if (isInsideCells && IsCellValid() && !isVisited)
                {
                    traversableCells.Add(_currentPos);
                }

                _visitedCells.Add(_currentPos);
            }
        }

        void EnqueueNextNeighbours(Vector2Int currentPos)
        {
            _currentNeighbours = GenerateNeigbours(currentPos);

            foreach (Vector2Int cellVector in _currentNeighbours)
            {
                if (!_visitedCells.Contains(cellVector) && !_nextNeighboursQueue.Contains(cellVector))
                {
                    _nextNeighboursQueue.Enqueue(cellVector);
                }
            }
        }

        protected abstract bool IsCellValid();

        void CopyNextQueueToCurrent()
        {
            foreach (Vector2Int cellVector in _nextNeighboursQueue)
            {
                _currentNeighboursQueue.Enqueue(cellVector);
            }
        }
    }
}
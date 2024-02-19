using System;
using System.Collections.Generic;
using Immortal.Entities;
using UnityEngine;

namespace Immortal.App
{
    public class MovementValidator : IMovementValidator
    {
        ISquareCells _squareCells;
        Vector2Int _currentPos;
        List<Vector2Int> _currentNeighbours = new List<Vector2Int>();
        List<Vector2Int> _visitedCells = new List<Vector2Int>();
        Queue<Vector2Int> _currentNeighboursQueue = new Queue<Vector2Int>();
        Queue<Vector2Int> _nextNeighboursQueue = new Queue<Vector2Int>();

        public MovementValidator(ISquareCells squareCells)
        {
            _squareCells = squareCells;
        }
        
        public List<Vector2Int> GetTraversableCells(Vector2Int startPos, int currentMoveRange)
        {
            Reset();
            _currentPos = startPos;
            
            var traversableCells = new List<Vector2Int>();

            EnqueueCurrentNeighboursOf(_currentPos);
            AddToVisitedCells(_currentPos);

            while (currentMoveRange > 0)
            {
                FindTraversableCells(traversableCells);

                CopyNextQueueToCurrent();
                _nextNeighboursQueue.Clear();

                currentMoveRange--;
            }

            return traversableCells;
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

            Vector2Int forwardNeighbour = Vector2Int.up;
            Vector2Int leftNeigbour = Vector2Int.left;
            Vector2Int backNeighbour = Vector2Int.down;
            Vector2Int rightNeighbour = Vector2Int.right;

            neighbours.Add(forwardNeighbour);
            neighbours.Add(leftNeigbour);
            neighbours.Add(backNeighbour);
            neighbours.Add(rightNeighbour);

            return neighbours;
        }

        void AddToVisitedCells(Vector2Int currentPos)
        {
            _visitedCells.Add(currentPos);
        }

        void FindTraversableCells(List<Vector2Int> traversableCells)
        {
            while (_currentNeighboursQueue.Count > 0)
            {
                if (_currentNeighboursQueue.Count > 100)
                {
                    throw new Exception("Finding traversable cells exceeded 100 iterations");
                }

                _currentPos = _currentNeighboursQueue.Dequeue();
                // EnqueueNextNeighbours(_currentPos);

                // bool isInsideCells = _squareCells.IsInsideCells(_currentPos);
                // bool isCellOccupied = _squareCells.IsCellOccupied(_currentPos);
                bool isVisited = _visitedCells.Contains(_currentPos);

                // if (isInsideCells && !isCellOccupied && !isVisited)
                // {
                //     traversableCells.Add(_currentPos);
                // }

                _visitedCells.Add(_currentPos);
            }
        }

        void CopyNextQueueToCurrent()
        {
            
        }
    }

    public interface IMovementValidator
    {
        List<Vector2Int> GetTraversableCells(Vector2Int startPos, int currentMoveRange);
    }
}
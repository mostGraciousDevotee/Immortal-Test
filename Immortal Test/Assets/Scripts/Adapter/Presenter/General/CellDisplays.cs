using System.Collections.Generic;
using UnityEngine;

using Immortal.Presenter;
using Immortal.PresenterFactory;

namespace Immortal.PresenterImplementation
{
    [RequireComponent(typeof(ICellDisplayBuilder))]
    public class CellDisplays : MonoBehaviour, ICellDisplays
    {
        Dictionary<string, ICellDisplay> _cellDisplayDict = new Dictionary<string, ICellDisplay>();

        ICellDisplayBuilder _cellDisplayBuilder;
        List<ICellDisplay> _cellDisplays = new List<ICellDisplay>();

        void Awake()
        {
            ICellDisplayPrefabs cellDisplayContainer = GetComponent<ICellDisplayPrefabs>();

            var movePrefab = cellDisplayContainer.MoveDisplayPrefab;
            var attackPrefab = cellDisplayContainer.AttackDisplayPrefab;

            _cellDisplayDict.Add(movePrefab.DisplayType, movePrefab);
            _cellDisplayDict.Add(attackPrefab.DisplayType, attackPrefab);

            _cellDisplayBuilder = GetComponent<CellDisplayBuilder>();
        }

        public void Show(string displayType, int cellSize, List<Vector2Int> validPos)
        {
            var cellDisplay = _cellDisplayDict[displayType];

            if (cellDisplay != null)
            {
                _cellDisplays = _cellDisplayBuilder.Build(cellDisplay, cellSize, validPos);
            }
            else
            {
                Debug.LogError("Failed to fetch cellDisplay!");
            }
        }

        public void Hide()
        {
            foreach (ICellDisplay cellDisplay in _cellDisplays)
            {
                cellDisplay.Hide();
            }

            _cellDisplays.Clear();
        }
    }
}
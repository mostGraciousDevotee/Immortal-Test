using System.Collections.Generic;
using UnityEngine;

using Immortal.Presenter;
using Immortal.PresenterFactory;

namespace Immortal.PresenterImplementation
{
    [RequireComponent(typeof(ICellDisplayBuilder))]
    public class CellDisplays : MonoBehaviour, ICellDisplays
    {
        ICellDisplayBuilder _cellDisplayBuilder;
        List<ICellDisplay> _cellDisplays = new List<ICellDisplay>();
        
        public void Init(int cellSize)
        {
            _cellDisplayBuilder = GetComponent<CellDisplayBuilder>();
            _cellDisplayBuilder.Init(cellSize);
        }

        public void Show(ICellDisplay cellDisplayPrefab, List<Vector2Int> validPos)
        {
            _cellDisplays = _cellDisplayBuilder.Build(cellDisplayPrefab, validPos);
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
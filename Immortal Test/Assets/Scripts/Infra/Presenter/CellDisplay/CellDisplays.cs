using System;
using System.Collections.Generic;
using UnityEngine;
using Immortal.App;
using Immortal.Factory;

namespace Immortal.View
{
    [RequireComponent(typeof(ICellDisplayBuilder))]
    public class CellDisplays : MonoBehaviour, ICellDisplays
    {
        ICellDisplayBuilder _cellDisplayBuilder;
        ICellDisplay _cellDisplayPrefab;
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
            if (_cellDisplays[0] as CellDisplay != null)
            {
                foreach (ICellDisplay cellDisplay in _cellDisplays)
                {
                    var cellDisplayImpl = cellDisplay as CellDisplay;
                    Destroy(cellDisplayImpl.gameObject);
                }
            }
            else
            {
                throw new Exception("Unable to destroy; ICellDisplay casting failed");
            }
        }
    }
}
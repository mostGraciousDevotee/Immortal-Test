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
        
        public void Init(int cellSize)
        {
            _cellDisplayBuilder = GetComponent<CellDisplayBuilder>();
            _cellDisplayBuilder.Init(cellSize);
        }

        public void Show(ICellDisplay cellDisplayPrefab, List<Vector2Int> validPos)
        {
            _cellDisplayBuilder.Build(cellDisplayPrefab, validPos);
        }
    }
}
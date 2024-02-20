using System.Collections.Generic;
using UnityEngine;
using Immortal.App;
using Immortal.View;

namespace Immortal.Factory
{
    public class CellDisplayBuilder : MonoBehaviour, ICellDisplayBuilder
    {
        int _cellSize;

        public void Init(int cellSize)
        {
            _cellSize = cellSize;
        }

        public List<ICellDisplay> Build(ICellDisplay cellDisplayPrefab, List<Vector2Int> validPos)
        {
            var cellDisplays = new List<ICellDisplay>();
            
            for (int i = 0; i < validPos.Count; i++)
            {
                float x = validPos[i].x * _cellSize;
                float z = validPos[i].y * _cellSize;
                Vector3 spawnPos = new Vector3(x, 0, z);

                var cellDisplay = Instantiate<CellDisplay>
                (
                    cellDisplayPrefab as CellDisplay,
                    spawnPos,
                    Quaternion.identity
                );
                cellDisplays.Add(cellDisplay);
            }

            return cellDisplays;
        }
    }
}
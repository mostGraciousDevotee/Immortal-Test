using System.Collections.Generic;
using UnityEngine;

using Immortal.PresenterFactory;
using Immortal.Presenter;

namespace Immortal.PresenterImplementation
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

                var cellDisplay = cellDisplayPrefab.Clone(spawnPos, Quaternion.identity);
                cellDisplays.Add(cellDisplay);
            }

            return cellDisplays;
        }

        public List<ICellDisplay> Build
        (
            ICellDisplay cellDisplayPrefab,
            int cellSize,
            List<Vector2Int> validPos
        )
        {
            _cellSize = cellSize;
            var cellDisplays = new List<ICellDisplay>();

            for (int i = 0; i < validPos.Count; i++)
            {
                float x = validPos[i].x * _cellSize;
                float z = validPos[i].y * _cellSize;
                Vector3 spawnPos = new Vector3(x, 0, z);

                var cellDisplay = cellDisplayPrefab.Clone(spawnPos, Quaternion.identity);
                cellDisplays.Add(cellDisplay);
            }

            return cellDisplays;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Immortal.App
{
    public interface ICellDisplayBuilder
    {
        void Init(int cellSize);
        List<ICellDisplay> Build(ICellDisplay cellDisplayPrefab, List<Vector2Int> validPos);
    }
}
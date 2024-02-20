using System.Collections.Generic;
using UnityEngine;

namespace Immortal.App
{
    public interface ICellDisplays
    {
        void Show(ICellDisplay cellDisplayPrefab, List<Vector2Int> validPos);
    }
}
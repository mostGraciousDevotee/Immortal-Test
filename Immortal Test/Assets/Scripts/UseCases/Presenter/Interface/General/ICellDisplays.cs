using System.Collections.Generic;
using UnityEngine;

namespace Immortal.Presenter
{
    public interface ICellDisplays
    {
        void Show(ICellDisplay cellDisplayPrefab, List<Vector2Int> validPos);
        void Hide();
    }
}
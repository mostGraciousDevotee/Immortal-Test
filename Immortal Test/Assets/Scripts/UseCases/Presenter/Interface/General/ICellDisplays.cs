using System.Collections.Generic;
using UnityEngine;

namespace Immortal.Presenter
{
    public interface ICellDisplays
    {
        void Show(string displayType, int cellSize, List<Vector2Int> validPos);
        void Hide();
    }
}
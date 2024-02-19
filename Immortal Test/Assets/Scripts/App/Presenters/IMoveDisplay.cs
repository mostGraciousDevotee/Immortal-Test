using System.Collections.Generic;
using UnityEngine;

namespace Immortal.App
{
    public interface IMoveDisplay
    {
        void Show(List<Vector2Int> validCells);
    }
}
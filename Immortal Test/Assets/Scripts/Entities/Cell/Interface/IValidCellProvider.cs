using System.Collections.Generic;
using UnityEngine;

namespace Immortal.CellSystem
{
    public interface IValidCellProvider
    {
        List<Vector2Int> GetValidCells(Vector2Int startPos, int range);
    }
}

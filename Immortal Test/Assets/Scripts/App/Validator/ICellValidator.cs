using System.Collections.Generic;
using UnityEngine;

public interface ICellValidator
{
    List<Vector2Int> GetValidCells(Vector2Int startPos, int range);
}
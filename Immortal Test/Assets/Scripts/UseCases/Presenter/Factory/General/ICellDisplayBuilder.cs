using System.Collections.Generic;
using UnityEngine;
using Immortal.Presenter;

namespace Immortal.PresenterFactory
{
    public interface ICellDisplayBuilder
    {
        void Init(int cellSize);
        List<ICellDisplay> Build(ICellDisplay cellDisplayPrefab, List<Vector2Int> validPos);
    }
}
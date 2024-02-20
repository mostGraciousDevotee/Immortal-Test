using UnityEngine;

namespace Immortal.App
{
    public interface IUnitPresenter
    {
        void Init(int cellSize);
        void SetPosition(Vector2Int position);
    }
}
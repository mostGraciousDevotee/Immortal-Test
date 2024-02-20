using Immortal.App;
using UnityEngine;

namespace Immortal.View
{
    public class UnitPresenter : MonoBehaviour, IUnitPresenter, IMarkable
    {
        public Transform Transform => transform;
        int _cellSize;

        public void Init(int cellSize)
        {
            _cellSize = cellSize;
        }

        public void SetPosition(Vector2Int position)
        {
            transform.position = new Vector3
            (
                position.x * _cellSize,
                transform.position.y,
                position.y * _cellSize);
        }
    }
}
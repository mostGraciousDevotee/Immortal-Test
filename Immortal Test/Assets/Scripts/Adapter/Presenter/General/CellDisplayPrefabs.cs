using UnityEngine;

using Immortal.Presenter;
using Immortal.PresenterFactory;

namespace Immortal.PresenterImplementation
{
    public class CellDisplayPrefabs : MonoBehaviour, ICellDisplayPrefabs
    {
        [SerializeField] CellDisplay _moveDisplay;
        [SerializeField] CellDisplay _attackDisplay;

        public ICellDisplay AttackDisplayPrefab => _attackDisplay;
        public ICellDisplay MoveDisplayPrefab => _moveDisplay;
    }
}
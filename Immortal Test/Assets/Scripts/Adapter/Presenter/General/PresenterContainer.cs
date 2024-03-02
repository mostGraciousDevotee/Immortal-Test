using UnityEngine;

using Immortal.Presenter;
using Immortal.PresenterFactory;

namespace Immortal.PresenterImplementation
{
    public class PresenterContainer : MonoBehaviour, ICellDisplayContainer
    {
        [SerializeField] CellDisplay _moveDisplay;
        [SerializeField] CellDisplay _attackDisplay;
        [SerializeField] CellDisplays _cellDisplays;
        [SerializeField] Panel _actionPanel;

        public ICellDisplay AttackDisplayPrefab => _attackDisplay;
        public ICellDisplay MoveDisplayPrefab => _moveDisplay;
        public ICellDisplays CellDisplays => _cellDisplays;

        public IHideable ActionPanel => _actionPanel;

        public void Init(int cellSize)
        {
            _cellDisplays.Init(cellSize);
        }
    }
}
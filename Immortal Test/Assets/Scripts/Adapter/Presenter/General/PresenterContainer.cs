using UnityEngine;

using Immortal.PresenterFactory;
using Immortal.Presenter;

namespace Immortal.PresenterImplementation
{
    public class PresenterContainer : MonoBehaviour, IPresenterContainer
    {
        [SerializeField] CellDisplays _cellDisplays;
        [SerializeField] Panel _actionPanel;

        public ICellDisplays CellDisplays => _cellDisplays;

        public IHideable ActionPanel => _actionPanel;
    }
}
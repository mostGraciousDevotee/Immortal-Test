using UnityEngine;

using Immortal.PresenterFactory;
using Immortal.UnitPresenterSystem;

namespace Immortal.PresenterImplementation
{   
    public class UnitPresenters : MonoBehaviour, IUnitPresenters
    {
        [SerializeField] UnitPresenter _adam;
        [SerializeField] UnitPresenter _bruce;

        public IUnitPresenter Adam => _adam;
        public IUnitPresenter Bruce => _bruce;
    }
}
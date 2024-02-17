using UnityEngine;
using Immortal.App;
using Immortal.View;

namespace Immortal.Factory
{
    public class UnitPresenters : MonoBehaviour, App.IUnitPresenters
    {
        [SerializeField] UnitPresenter _adam;
        [SerializeField] UnitPresenter _bruce;

        public IUnitPresenter Adam => _adam;
        public IUnitPresenter Bruce => _bruce;
    }
}
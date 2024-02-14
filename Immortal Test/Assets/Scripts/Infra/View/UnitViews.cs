using Immortal.App;
using UnityEngine;

namespace Immortal.Infra.View
{
    public class UnitViews : MonoBehaviour, IUnitViews
    {
        [SerializeField] UnitView _adam;
        [SerializeField] UnitView _bruce;

        public IUnitView Adam => _adam;
        public IUnitView Bruce => _bruce;
    }
}
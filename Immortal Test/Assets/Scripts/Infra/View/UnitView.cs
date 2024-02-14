using Immortal.App;
using UnityEngine;

namespace Immortal.Infra.View
{
    public class UnitView : MonoBehaviour, IMarkable, IUnitView
    {
        public Transform Transform => transform;
    }
}
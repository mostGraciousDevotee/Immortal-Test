using Immortal.App;
using UnityEngine;

namespace Immortal.View
{
    public class UnitPresenter : MonoBehaviour, IMarkable, IUnitPresenter
    {
        public Transform Transform => transform;
    }
}
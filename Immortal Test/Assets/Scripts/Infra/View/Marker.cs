using Immortal.App;
using UnityEngine;

namespace Immortal.View
{
    public class Marker : MonoBehaviour, IMarker
    {
        [SerializeField] Vector3 _offset = new Vector3(0, 2.2f, 0);

        void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Mark(IUnitPresenter unitView)
        {
            var markable = unitView as UnitPresenter;
            
            gameObject.SetActive(true);
            transform.SetParent(markable.Transform, false);
            transform.localPosition = _offset;
        }

        internal void Unmark()
        {
            transform.parent = null;
        }
    }

    public interface IMarkable
    {
        Transform Transform { get; }
    }
}
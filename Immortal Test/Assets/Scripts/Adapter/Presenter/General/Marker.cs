using UnityEngine;
using Immortal.Presenter;

namespace Immortal.PresenterImplementation
{
    public class Marker : MonoBehaviour, IMarker
    {
        [SerializeField] Vector3 _offset = new Vector3(0, 2.2f, 0);

        void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Mark(IMarkable markable)
        {
            var monobehaviour = (MonoBehaviour) markable;
            
            gameObject.SetActive(true);
            transform.SetParent(monobehaviour.transform, false);
            transform.localPosition = _offset;
        }

        internal void Unmark()
        {
            transform.parent = null;
        }
    }
}
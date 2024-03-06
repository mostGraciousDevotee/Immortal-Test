using UnityEngine;
using Immortal.Presenter;

namespace Immortal.PresenterImplementation
{
    public class CellDisplay : MonoBehaviour, ICellDisplay
    {
        [SerializeField] string _displayType;

        public string DisplayType => _displayType;

        public ICellDisplay Clone(Vector3 spawnPos, Quaternion quaternion)
        {   
            return Instantiate<CellDisplay>(this, spawnPos, quaternion);
        }

        public void Hide()
        {
            Destroy(gameObject);
        }
    }
}
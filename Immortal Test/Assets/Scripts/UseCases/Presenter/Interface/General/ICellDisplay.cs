using UnityEngine;

namespace Immortal.Presenter
{
    public interface ICellDisplay
    {
        string DisplayType {get; }
        ICellDisplay Clone(Vector3 spawnPos, Quaternion quaternion);
        void Hide();
    }
}
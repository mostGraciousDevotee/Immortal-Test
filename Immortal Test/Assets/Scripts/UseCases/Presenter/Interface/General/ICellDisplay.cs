using UnityEngine;

namespace Immortal.Presenter
{
    public interface ICellDisplay
    {
        ICellDisplay Clone(Vector3 spawnPos, Quaternion quaternion);
        void Hide();
    }
}
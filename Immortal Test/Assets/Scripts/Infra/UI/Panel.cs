using Immortal.App;
using UnityEngine;

namespace Immortal.UI
{
    public class Panel : MonoBehaviour, IHideable
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
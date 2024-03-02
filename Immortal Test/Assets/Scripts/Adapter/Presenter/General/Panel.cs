using UnityEngine;

namespace Immortal.Presenter
{
    // TODO: This can be merged with ActionButtons
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
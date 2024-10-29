using UnityEngine;
using UnityEngine.Events;

namespace Tatedrez.Behaviours
{
    [RequireComponent(typeof(Collider2D))]
    public class SelectableBehaviour : MonoBehaviour
    {
        public UnityEvent<bool> OnSelected;

        public bool IsSelected { get; protected set; }

        public virtual void SetSelected(bool selected)
        {
            IsSelected = selected;
        }

        private void OnMouseUpAsButton()
        {
            IsSelected = !IsSelected;
            SetSelected(IsSelected);
        }

    }
}
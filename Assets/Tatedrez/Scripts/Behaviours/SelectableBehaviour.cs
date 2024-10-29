using UnityEngine;
using UnityEngine.Events;

namespace Tatedrez.Behaviours
{
    [RequireComponent(typeof(Collider2D))]
    public class SelectableBehaviour : MonoBehaviour
    {
        public UnityEvent<bool> OnSelected;

        public bool IsSelected { get; private set; }

        private void OnMouseUpAsButton()
        {
            IsSelected = !IsSelected;
            OnSelected?.Invoke(IsSelected);
        }
    }
}
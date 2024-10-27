using UnityEngine;

namespace Tatedrez.View.BoardView
{
    public class BoardCellView : MonoBehaviour
    {
        public float Size => _collider.size.x;

        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        private void Reset()
        {
            _collider = GetComponent<BoxCollider2D>();
        }

        private void OnValidate()
        {
            if (_collider == null)
                _collider = GetComponent<BoxCollider2D>();
        }
    }
}
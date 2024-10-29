using DG.Tweening;
using System;
using UnityEngine;

namespace Tatedrez.View.BoardView
{
    public class BoardCellView : MonoBehaviour
    {
        public event Action<BoardCellView> OnCellClicked;

        public float Size => _collider.size.x;
        public bool IsAvailable { get => _isAvailable;
            set {
                _isAvailable = value;
                _spriteRenderer.DOKill();
                _spriteRenderer.DOFade(_isAvailable ? 1.0f : 0.6f, _fadeDuration);
            } 
        }

        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _fadeDuration = 0.2f;

        private bool _isAvailable;

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        private void OnMouseUpAsButton()
        {
            if (!IsAvailable)
                return;

            OnCellClicked?.Invoke(this);
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
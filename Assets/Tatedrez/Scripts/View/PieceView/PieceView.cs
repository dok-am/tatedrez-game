using DG.Tweening;
using Tatedrez.View.PieceView.Interfaces;
using UnityEngine;

namespace Tatedrez.View.PieceView
{
    public class PieceView : MonoBehaviour, IPieceView
    {
        [SerializeField] private Transform _transform;

        [Header("Components")]
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [Header("Animations")]
        [SerializeField] private float _defaultScale = 1.0f;
        [SerializeField] private float _selectedScale = 1.1f;
        [SerializeField] private float _selectAnimationDuration = 0.2f;
        [SerializeField] private float _movePieceAnimationDuration = 1.0f;

        public void SetSelected(bool selected)
        {
            _transform.DOKill();
            float targetScale = selected ? _selectedScale : _defaultScale;
            _transform.DOScale(Vector2.one * targetScale, _selectAnimationDuration);
        }

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        public void Move(Vector2 position)
        {
            
        }

        public void Enable(bool enabled)
        {
            gameObject.SetActive(enabled);
        }

        private void Reset()
        {
            _transform = transform;
        }

        private void OnValidate()
        {
            if (_transform == null)
                _transform = transform;
        }
    }
}
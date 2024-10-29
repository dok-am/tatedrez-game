using DG.Tweening;
using System;
using Tatedrez.Behaviours;
using Tatedrez.View.PieceView.Interfaces;
using UnityEngine;

namespace Tatedrez.View.PieceView
{
    public class PieceView : SelectableBehaviour, IPieceView
    {
        public event Action<IPieceView, bool> OnPieceSelected;

        [SerializeField] private Transform _transform;

        [Header("Components")]
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [Header("Animations")]
        [SerializeField] private float _defaultScale = 1.0f;
        [SerializeField] private float _selectedScale = 1.1f;
        [SerializeField] private float _selectAnimationDuration = 0.2f;
        [SerializeField] private float _movePieceAnimationDuration = 1.0f;


        public override void SetSelected(bool selected)
        {
            SetSelected(selected, false);
        }

        public void SetSelected(bool selected, bool forced = false)
        {
            base.SetSelected(selected);

            _transform.DOKill();
            float targetScale = selected ? _selectedScale : _defaultScale;
            _transform.DOScale(Vector2.one * targetScale, _selectAnimationDuration);

            if (!forced)
                OnPieceSelected?.Invoke(this, selected);
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
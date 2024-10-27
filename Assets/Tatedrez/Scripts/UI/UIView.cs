using DG.Tweening;
using System;
using Tatedrez.UI.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tatedrez.UI
{
    public class UIView : MonoBehaviour, IUIView
    {
        public event Action OnActionButtonClicked;

        [Header("Objects")]
        [SerializeField] private TMP_Text _statusLabel;
        [SerializeField] private Button _actionButton;
        [SerializeField] private CanvasGroup _buttonCanvasGroup;
        [SerializeField] private TMP_Text _buttonLabel;

        [Header("Settings")]
        [SerializeField] private float _transitionsDuration = 0.3f;

        public void SetStatusText(string text, Color color)
        {
            ShowStatusText(false, () =>
            {
                _statusLabel.text = text;
                _statusLabel.color = color;
                ShowStatusText(true);
            });            
        }

        public void SetActionButtonText(string text)
        {
            _buttonLabel.text = text;
        }

        public void ShowStatusText(bool show, Action onComplete = null)
        {
            _statusLabel.DOKill();
            _statusLabel.DOFade(show ? 1.0f : 0.0f, _transitionsDuration)
                .OnComplete(() => onComplete?.Invoke());
        }

        public void ShowActionButton(bool show, Action onComplete = null)
        {
            _buttonCanvasGroup.DOKill();
            _actionButton.interactable = show;
            _buttonCanvasGroup.DOFade(show ? 1.0f : 0.0f, _transitionsDuration)
                .OnComplete(() => onComplete?.Invoke()); ;
        }

        private void OnEnable()
        {
            _actionButton.onClick.AddListener(ActionButtonClickHandler);
        }

        private void OnDisable()
        {
            _actionButton.onClick.RemoveListener(ActionButtonClickHandler);
        }

        private void ActionButtonClickHandler()
        {
            OnActionButtonClicked?.Invoke();
        }
    }
}
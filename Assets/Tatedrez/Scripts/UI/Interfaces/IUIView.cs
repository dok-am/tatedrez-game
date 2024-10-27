using System;
using UnityEngine;

namespace Tatedrez.UI.Interfaces
{
    public interface IUIView
    {
        public event Action OnActionButtonClicked;

        public void SetStatusText(string text, Color color);
        public void SetActionButtonText(string text);
        public void ShowStatusText(bool show, Action onComplete = null);
        public void ShowActionButton(bool show, Action onComplete = null);
    }
}
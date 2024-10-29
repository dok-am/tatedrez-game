using System;
using UnityEngine;

namespace Tatedrez.View.PieceView.Interfaces
{
    public interface IPieceView
    {
        public event Action<IPieceView, bool> OnPieceSelected;

        public void SetSelected(bool selected, bool forced);
        public void SetSprite(Sprite sprite);
        public void Move(Vector2 position);
        public void Enable(bool enabled);
    }
}
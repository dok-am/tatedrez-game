using UnityEngine;

namespace Tatedrez.View.PieceView.Interfaces
{
    public interface IPieceView
    {
        public void SetSelected(bool selected);
        public void SetSprite(Sprite sprite);
        public void Move(Vector2 position);
        public void Enable(bool enabled);
    }
}
using System;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Services.BoardService.Interface
{
    public interface IBoardService
    {
        public event Action<IPiece> OnPieceChangedPosition;

        public IBoard Board { get; }

        public void SetPieceToPosition(IPiece piece, int index);
        public void MovePieceToCell(IPiece piece, IBoardCell cell);
        public void ClearBoard();
    }
}
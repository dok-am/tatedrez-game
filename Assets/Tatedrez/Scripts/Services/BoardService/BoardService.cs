using System;
using Tatedrez.Application;
using Tatedrez.Data;
using Tatedrez.Data.Interfaces;
using Tatedrez.Services.BoardService.Interface;

namespace Tatedrez.Services.BoardService
{
    public class BoardService : IBoardService
    {
        public event Action<IPiece> OnPieceChangedPosition;

        public IBoard Board => _board;

        private Board _board;

        public BoardService(GameplaySceneBinder sceneBinder)
        {
            _board = new(sceneBinder.GameConfig.BoardSize);
        }

        public void ClearBoard()
        {
            _board.Clear();
        }

        public void SetPieceToPosition(IPiece piece, int index)
        {
            _board.SetPieceToPosition(piece, index);
            OnPieceChangedPosition?.Invoke(piece);
        }
    }
}
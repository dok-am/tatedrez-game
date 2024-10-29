
using Tatedrez.Data.Interfaces;
using Tatedrez.Services.BoardService.Interface;

namespace Tatedrez.Services.Pieces
{
    public class PiecesManager 
    {
        private IPiece _selectedPiece;
        private IBoardService _boardService;

        public PiecesManager(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public void SelectPiece(IPiece piece, bool select)
        {
            _selectedPiece = select ? piece : null;
        }

        public void MoveSelectedPieceToCell(IBoardCell cell)
        {
            _boardService.MovePieceToCell(_selectedPiece, cell);
        }
    }
}
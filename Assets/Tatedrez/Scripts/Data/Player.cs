using System.Collections.Generic;
using Tatedrez.Data.Enums;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Data
{
    public class Player : IPlayer
    {
        public PlayerColor Color { get; private set; }
        public IReadOnlyList<IPiece> FreePieces => _freePieces;
        public IReadOnlyList<IPiece> PiecesOnBoard => _piecesOnBoard;

        private List<Piece> _freePieces = new((int)PieceType.TypesCount);
        private List<Piece> _piecesOnBoard = new((int)PieceType.TypesCount);

        public Player(PlayerColor color)
        {
            Color = color;

            ResetState();
        }

        public bool IsPieceOnBoard(IPiece piece)
        {
            if (piece is Piece pieceInstance)
                return _piecesOnBoard.Contains(pieceInstance);

            return false;
        }

        public void PutPieceOnBoard(Piece piece)
        {
            if (!_freePieces.Contains(piece))
                throw new System.Exception($"Can't put {piece.Type} on board: it's not available");

            _freePieces.Remove(piece);
            _piecesOnBoard.Add(piece);
        }

        public void ResetState()
        {
            _freePieces.Clear();
            _piecesOnBoard.Clear();

            int piecesCount = (int)PieceType.TypesCount;
            for (int i = 0; i < piecesCount; i++)
            {
                PieceType pieceType = (PieceType)i;
                _freePieces.Add(new Piece(pieceType));
            }
        }

        public override int GetHashCode()
        {
            return (int)Color;
        }
    }
}
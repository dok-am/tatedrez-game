using System.Collections.Generic;

namespace Tatedrez.Data.Interfaces
{
    public interface IPlayer 
    {
        public PlayerColor Color { get; }
        public IReadOnlyList<IPiece> FreePieces { get; }
        public IReadOnlyList<IPiece> PiecesOnBoard { get; }

        public void PutPieceOnBoard(Piece piece);
        public void ResetState();
    }
}
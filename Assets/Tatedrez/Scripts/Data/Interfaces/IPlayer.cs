using System.Collections.Generic;
using Tatedrez.Data.Enums;

namespace Tatedrez.Data.Interfaces
{
    public interface IPlayer 
    {
        public PlayerColor Color { get; }
        public IReadOnlyList<IPiece> FreePieces { get; }
        public IReadOnlyList<IPiece> PiecesOnBoard { get; }

        public bool IsPieceOnBoard(IPiece piece);
        public void PutPieceOnBoard(Piece piece);
        public void ResetState();
    }
}
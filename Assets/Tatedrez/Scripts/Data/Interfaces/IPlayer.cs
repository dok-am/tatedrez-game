using System.Collections.Generic;
using Tatedrez.Configs;

namespace Tatedrez.Data.Interfaces
{
    public interface IPlayer 
    {
        public PlayerColor Color { get; }
        public IReadOnlyList<IPiece> FreePieces { get; }

        public PieceConfig GetConfigForPiece(PieceType type);
    }
}
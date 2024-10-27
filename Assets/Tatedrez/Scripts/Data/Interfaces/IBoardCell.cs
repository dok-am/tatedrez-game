using System.Collections.Generic;

namespace Tatedrez.Data.Interfaces
{
    public interface IBoardCell 
    {
        public IReadOnlyDictionary<BoardCellRelativePosition, IBoardCell> NearbyCells { get; }

        public IPiece Piece { get; }
    }
}
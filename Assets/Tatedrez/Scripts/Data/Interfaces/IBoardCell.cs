using System.Collections.Generic;
using Tatedrez.Data.Enums;

namespace Tatedrez.Data.Interfaces
{
    public interface IBoardCell 
    {
        public IReadOnlyDictionary<BoardCellRelativePosition, IBoardCell> NearbyCells { get; }

        public IPiece Piece { get; }
    }
}
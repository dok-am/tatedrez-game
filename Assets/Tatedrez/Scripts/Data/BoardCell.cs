using System.Collections.Generic;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Data
{
    public class BoardCell : IBoardCell
    {
        public IReadOnlyDictionary<BoardCellRelativePosition, IBoardCell> NearbyCells => MutableNearbyCells;

        public IPiece Piece { get; set; }

        public readonly Dictionary<BoardCellRelativePosition, IBoardCell> MutableNearbyCells = new();
    }
}
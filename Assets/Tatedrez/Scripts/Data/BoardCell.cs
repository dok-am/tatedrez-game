using System.Collections.Generic;
using Tatedrez.Data.Enums;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Data
{
    public class BoardCell : IBoardCell
    {
        public IReadOnlyDictionary<BoardCellRelativePosition, IBoardCell> NearbyCells => MutableNearbyCells;

        public IPiece Piece { get; set; }

        public int RowIndex { get; set; }

        public int ColIndex { get; set; }

        public readonly Dictionary<BoardCellRelativePosition, IBoardCell> MutableNearbyCells = new();

        public override int GetHashCode()
        {
            var hashcode = 23;
            hashcode = (hashcode * 37) + RowIndex;
            hashcode = (hashcode * 37) + ColIndex;
            return hashcode;
        }
    }
}
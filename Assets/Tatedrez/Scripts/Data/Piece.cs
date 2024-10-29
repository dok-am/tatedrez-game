using Tatedrez.Data.Enums;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Data
{
    public class Piece : IPiece
    {
        public PieceType Type { get; private set; }

        public Piece(PieceType type)
        {
            Type = type;
        }

        public override int GetHashCode()
        {
            return (int)Type;
        }
    }
}
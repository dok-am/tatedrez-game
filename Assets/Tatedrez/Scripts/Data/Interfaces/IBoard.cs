
namespace Tatedrez.Data.Interfaces
{
    public interface IBoard 
    {
        public int Size { get; }

        public IBoardCell GetCell(int index);
    }
}
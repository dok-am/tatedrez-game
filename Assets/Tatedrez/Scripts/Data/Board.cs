using Tatedrez.Data.Interfaces;

namespace Tatedrez.Data
{
    public class Board : IBoard
    {
        public int Size { get; private set; }

        private const int CellSurroundingGridSize = 3;

        private BoardCell[] _grid;

        public Board(int size)
        {
            Size = size;
            GenerateGrid();
        }

        public void Clear()
        {
            foreach(var cell in _grid)
            {
                cell.Piece = null;
            }
        }

        public IBoardCell GetCell(int index)
        {
            return _grid[index];
        }

        public void SetPieceToPosition(IPiece piece, int index)
        {
            _grid[index].Piece = piece;
        }

        private void GenerateGrid()
        {
            _grid = new BoardCell[Size * Size];

            for (int i = 0; i < Size * Size; i++)
            {
                int colIndex = i % Size;
                int rowIndex = i / Size;
                BoardCell newCell = new();

                _grid[i] = newCell;

                int itselfRelativePosition = (int)BoardCellRelativePosition.ItselfPosition;

                for (int j = 0; j < itselfRelativePosition; j++)
                {
                    int relativeRow = j / CellSurroundingGridSize;
                    int relativeCol = j % CellSurroundingGridSize;

                    int absoluteRow = rowIndex - (1 - relativeRow);
                    int absoluteCol = colIndex - (1 - relativeCol);

                    if (absoluteRow < 0 || absoluteRow >= Size
                        || absoluteCol < 0 || absoluteCol >= Size)
                        continue;

                    int absoluteIndex = i + j
                                        - (Size + 1 - relativeRow * (Size - CellSurroundingGridSize));

                    var relativeCellPosition = (BoardCellRelativePosition)j;
                    newCell.MutableNearbyCells[relativeCellPosition] = _grid[absoluteIndex];

                    var invertedIndex = BoardCellRelativePosition.BottomRight - j;
                    _grid[absoluteIndex].MutableNearbyCells[invertedIndex] = newCell;
                }
            }
        }
    }
}
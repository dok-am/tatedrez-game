using System;
using Tatedrez.Application;
using Tatedrez.Data.Interfaces;
using Tatedrez.Helpers;
using UnityEngine;

namespace Tatedrez.View.BoardView
{
    public class BoardViewController 
    {
        public event Action<BoardViewController> OnBoardBuilded;
        public event Action<IBoardCell> OnCellClicked;

        public float CellSize => _cellSize;
        public float GridSize => _gridSize;
        public float BoardTotalSize => _cellSize * _gridSize;

        private BoardCellView _cellPrefab;
        private Sprite _whiteCellSprite;
        private Sprite _blackCellSprite;

        private BoardCellView[] _gridView;
        private BiDictionary<IBoardCell, BoardCellView> _boardDataConnection;
        private Transform _gridContainer;

        private float _cellSize;
        private float _gridSize;

        public BoardViewController(GameplaySceneBinder sceneBinder)
        {
            _cellPrefab = sceneBinder.BoardCellPrefab;
            _whiteCellSprite = sceneBinder.WhiteBoardCellSprite;
            _blackCellSprite = sceneBinder.BlackBoardCellSprite;
        }

        public void BuildBoard(IBoard board)
        {
            if (_gridContainer != null || _gridView != null)
                throw new Exception("Can't rebuild board on runtime");

            _gridContainer = new GameObject("BOARD").transform;
            _gridContainer.position = Vector3.zero;

            int arraySize = board.Size * board.Size;
            _gridView = new BoardCellView[arraySize];
            _boardDataConnection = new BiDictionary<IBoardCell, BoardCellView>(arraySize);

            _cellSize = _cellPrefab.Size;
            _gridSize = board.Size;

            float halfBoardSize = (_cellSize * board.Size) / 2.0f;
            float halfCellSize = (_cellSize / 2.0f);
            float beginOffsetX = - halfBoardSize + halfCellSize;
            float beginOffsetY = halfBoardSize - halfCellSize;
            Vector2 cellStartPosition = new(beginOffsetX, beginOffsetY);
            bool black = false;

            for (int i = 0; i < arraySize; i++)
            {
                int colIndex = i % board.Size;
                int rowIndex = i / board.Size;

                Vector2 cellPosition = cellStartPosition
                    + new Vector2(colIndex * _cellSize, -rowIndex * _cellSize);
                _gridView[i] = CreateBoardCellView(black, cellPosition);
                _boardDataConnection[board.GetCell(i)] = _gridView[i];

                black = !black;
            }

            OnBoardBuilded?.Invoke(this);
        }

        public void HighlightAvailableCellsForSet(bool highlight)
        {
            for(int i=0; i<_gridView.Length; i++)
            {
                BoardCellView boardCellView = _gridView[i];
                var cellData = _boardDataConnection.GetKeyForValue(boardCellView).Piece;
                boardCellView.IsAvailable = cellData == null && highlight;
            }
        }

        private BoardCellView CreateBoardCellView(bool black, Vector2 position)
        {
            BoardCellView newCell = GameObject.Instantiate(_cellPrefab, position, 
                Quaternion.identity, _gridContainer);

            newCell.SetSprite(black ? _blackCellSprite : _whiteCellSprite);
            newCell.OnCellClicked += CellClickedHandler;

            return newCell;
        }

        private void CellClickedHandler(BoardCellView cell)
        {
            OnCellClicked?.Invoke(_boardDataConnection.GetKeyForValue(cell));
        }
    }
}
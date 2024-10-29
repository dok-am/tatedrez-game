using System;
using UnityEngine;

namespace Tatedrez.Data
{
    [Serializable]
    public class PieceMovement
    {
        public bool Infinite => _infinite;
        public bool IsBlockedByOtherPieces => _isBlockedByOtherPieces;

        public BoardCellRelativePosition[] Direction => _direction;

        [SerializeField] private bool _infinite;
        [SerializeField] private bool _isBlockedByOtherPieces;
        [SerializeField] private BoardCellRelativePosition[] _direction;
    }
}
using Tatedrez.Data;
using Tatedrez.Data.Enums;
using UnityEngine;

namespace Tatedrez.Configs
{
    [CreateAssetMenu(fileName = "PieceMoveConfig", menuName = "Tatedrez/New piece movement config")]
    public class PieceMovementConfig : ScriptableObject
    {
        public PieceType PieceType => _pieceType;
        public PieceMovement[] MovementVariations => _movementsVariations;

        [SerializeField] private PieceType _pieceType;
        [SerializeField] private PieceMovement[] _movementsVariations;
    }
}
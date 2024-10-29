using UnityEngine;

namespace Tatedrez.Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Tatedrez/New game config")]
    public class GameConfig : ScriptableObject
    {
        public int BoardSize => _boardSize;
        public PieceMovementConfig[] PieceMovementConfigs => _pieceMovementConfigs;

        [SerializeField] private int _boardSize;
        [SerializeField] private PieceMovementConfig[] _pieceMovementConfigs;
    }
}
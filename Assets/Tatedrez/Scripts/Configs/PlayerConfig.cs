using Tatedrez.Data;
using UnityEngine;

namespace Tatedrez.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Tatedrez/New player config")]
    public class PlayerConfig : ScriptableObject
    {
        public PlayerColor Color => _color;
        public PieceConfig[] Pieces => _pieces;

        [SerializeField] private PlayerColor _color;
        [SerializeField] private PieceConfig[] _pieces;

        private void Reset()
        {
            int typesCount = (int)PieceType.TypesCount;
            _pieces = new PieceConfig[typesCount];

            for (int i = 0; i < typesCount; i++)
            {
                _pieces[i] = new PieceConfig((PieceType)i);
            }
        }

        private void OnValidate()
        {
            int typesCount = (int)PieceType.TypesCount;

            if (_pieces.Length < typesCount)
            {
                Debug.LogError($"Pieces config doesn't filled properly, " +
                    $"there should be {typesCount} entries with every type");
            }
        }
    }
}
using System;
using Tatedrez.Data;
using UnityEngine;

namespace Tatedrez.Configs
{
    [Serializable]
    public class PieceConfig 
    {
        public Sprite Sprite => _sprite;
        public PieceType Type => _type;
        public PieceMovement Movement => _movement;

        [SerializeField] private PieceType _type;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private PieceMovement _movement;

        public PieceConfig(PieceType type)
        {
            _type = type;
        }
    }
}
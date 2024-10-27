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

        [SerializeField] private PieceType _type;
        [SerializeField] private Sprite _sprite;

        public PieceConfig(PieceType type)
        {
            _type = type;
        }
    }
}
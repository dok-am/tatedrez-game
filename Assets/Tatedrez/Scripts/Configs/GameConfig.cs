using UnityEngine;

namespace Tatedrez.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Tatedrez/New game config")]
    public class GameConfig : ScriptableObject
    {
        public int BoardSize => _boardSize;

        [SerializeField] private int _boardSize;
    }
}
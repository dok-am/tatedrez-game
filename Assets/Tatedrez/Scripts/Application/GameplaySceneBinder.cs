using Tatedrez.Configs;
using UnityEngine;

namespace Tatedrez.Application
{
    public class GameplaySceneBinder : MonoBehaviour
    {
        public PlayerConfig[] PlayersConfigs => _playersConfigs;
        public GameConfig GameConfig => _gameConfig;

        [Header("Configs")]
        [SerializeField] private PlayerConfig[] _playersConfigs;
        [SerializeField] private GameConfig _gameConfig;
    }
}
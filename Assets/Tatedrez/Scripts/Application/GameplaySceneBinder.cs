using Tatedrez.Configs;
using UnityEngine;

namespace Tatedrez.Application
{
    public class GameplaySceneBinder : MonoBehaviour
    {
        public PlayerConfig[] PlayersConfigs => _playersConfigs;

        [Header("Configs")]
        [SerializeField] private PlayerConfig[] _playersConfigs;
    }
}
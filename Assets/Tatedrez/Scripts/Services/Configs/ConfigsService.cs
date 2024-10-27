using System.Collections.Generic;
using System.Linq;
using Tatedrez.Application;
using Tatedrez.Configs;
using Tatedrez.Data;
using Tatedrez.Services.Configs.Interfaces;

namespace Tatedrez.Services.Configs
{
    public class ConfigsService : IConfigsService
    {
        private Dictionary<PlayerColor, PlayerConfig> _playerConfigs = new();

        public ConfigsService(GameplaySceneBinder sceneBinder)
        {
            foreach (var playerConfig in sceneBinder.PlayersConfigs)
            {
                _playerConfigs.Add(playerConfig.Color, playerConfig);
            }
        }

        public PlayerConfig GetPlayerConfig(PlayerColor color)
        {
            if (_playerConfigs.TryGetValue(color, out var config))
                return config;

            throw new System.Exception($"Can't find config for player color {color}");
        }

        public PieceConfig GetConfigForPiece(PlayerColor color, PieceType type)
        {
            var playerConfig = GetPlayerConfig(color);
            var pieceConfig = playerConfig.Pieces.FirstOrDefault(config => config.Type == type);

            if (pieceConfig == null)
                throw new System.Exception($"Can't find config for player color {color} " +
                    $"and piece type {type}");

            return pieceConfig;
        }
    }
}
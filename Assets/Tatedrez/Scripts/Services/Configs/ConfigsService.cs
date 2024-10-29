using System.Collections.Generic;
using System.Linq;
using Tatedrez.Application;
using Tatedrez.Configs;
using Tatedrez.Data.Enums;
using Tatedrez.Services.Configs.Interfaces;

namespace Tatedrez.Services.Configs
{
    public class ConfigsService : IConfigsService
    {
        private Dictionary<PlayerColor, PlayerConfig> _playerConfigs = new();
        private Dictionary<PieceType, PieceMovementConfig> _pieceMovementConfigs = new();

        public ConfigsService(GameplaySceneBinder sceneBinder)
        {
            foreach (var playerConfig in sceneBinder.PlayersConfigs)
            {
                _playerConfigs.Add(playerConfig.Color, playerConfig);
            }

            foreach(var movementConfig in sceneBinder.GameConfig.PieceMovementConfigs)
            {
                _pieceMovementConfigs.Add(movementConfig.PieceType, movementConfig);
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

        public PieceMovementConfig GetMovementConfigForPiece(PieceType pieceType)
        {
            if (_pieceMovementConfigs.TryGetValue(pieceType, out var config))
                return config;

            throw new System.Exception($"Can't find config for piece type {pieceType}");
        }
    }
}
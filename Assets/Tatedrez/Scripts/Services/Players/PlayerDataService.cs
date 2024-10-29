using System.Collections.Generic;
using Tatedrez.Data;
using Tatedrez.Data.Enums;
using Tatedrez.Data.Interfaces;
using Tatedrez.Services.Players.Interfaces;

namespace Tatedrez.Services.Players
{
    public class PlayerDataService : IPlayerDataService
    {
        
        private Dictionary<PlayerColor, Player> _players = new();
        private int _playersCount;

        public PlayerDataService()
        {
            _playersCount = (int)PlayerColor.PlayersCount;
            for (int i = 0; i < _playersCount; i++)
            {
                PlayerColor color = (PlayerColor) i;
                _players.Add(color, new Player(color));
            }
        }

        public IPlayer GetPlayer(PlayerColor color)
        {
            if (_players.TryGetValue(color, out var player))
                return player;

            throw new System.Exception($"There is no player with color {color}");
        }

    }
}
using Tatedrez.Configs;
using Tatedrez.Data;

namespace Tatedrez.Services.Configs.Interfaces
{
    public interface IConfigsService 
    {
        public PlayerConfig GetPlayerConfig(PlayerColor color);
        public PieceConfig GetConfigForPiece(PlayerColor color, PieceType type);
    }
}
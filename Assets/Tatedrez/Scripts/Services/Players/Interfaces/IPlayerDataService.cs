using Tatedrez.Data.Enums;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Services.Players.Interfaces
{
    public interface IPlayerDataService 
    {
        public IPlayer GetPlayer(PlayerColor color);
        
    }
}
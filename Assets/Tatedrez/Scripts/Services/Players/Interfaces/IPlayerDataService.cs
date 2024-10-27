using Tatedrez.Data;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Services.Players.Interfaces
{
    public interface IPlayerDataService 
    {
        public IPlayer GetPlayer(PlayerColor color);
        
    }
}
using System;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Services.Instances.Interfaces
{
    public interface IInstancesManager 
    {
        public event Action<IPiece, bool> OnPieceSelected;

        public void ShowPlayerAvailablePieces(IPlayer player);
    }
}
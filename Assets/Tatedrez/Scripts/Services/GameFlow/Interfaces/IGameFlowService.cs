
using System;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Services.GameFlow.Interfaces
{
    public interface IGameFlowService 
    {
        public event Action<GameFlowState> OnStateSwitched;

        public GameFlowState CurrentState { get; }
        public IPlayer CurrentPlayer { get; }

        public void GoToNextState();
    }
}
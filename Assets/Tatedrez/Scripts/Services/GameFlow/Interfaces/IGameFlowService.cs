
using System;
using Tatedrez.Data.Interfaces;

namespace Tatedrez.Services.GameFlow.Interfaces
{
    public interface IGameFlowService 
    {
        public event Action<GameFlowState> OnStateSwitched;
        public event Action<IPlayer> OnPlayerBeginTurn;

        public GameFlowState CurrentState { get; }
        public IPlayer CurrentPlayer { get; }

        public void StartGameFlow();
        public void GoToNextState();
    }
}
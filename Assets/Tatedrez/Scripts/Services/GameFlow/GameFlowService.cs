using System;
using Tatedrez.Data.Enums;
using Tatedrez.Data.Interfaces;
using Tatedrez.Services.GameFlow.Interfaces;
using Tatedrez.Services.Instances.Interfaces;
using Tatedrez.Services.Players.Interfaces;

namespace Tatedrez.Services.GameFlow
{
    public class GameFlowService : IGameFlowService
    {
        public event Action<GameFlowState> OnStateSwitched;
        public event Action<IPlayer> OnPlayerBeginTurn;

        public GameFlowState CurrentState { get; private set; }
        public IPlayer CurrentPlayer => _currentPlayer;

        private IPlayerDataService _playerDataService;
        private IPlayer _currentPlayer;
        private IInstancesManager _instancesManager;

        public GameFlowService(IPlayerDataService playerDataService, IInstancesManager instancesManager)
        {
            _playerDataService = playerDataService;
            _instancesManager = instancesManager;
        }

        public void StartGameFlow()
        {
            CurrentState = GameFlowState.Initial;
            UpdateStateInternal();
            OnStateSwitched?.Invoke(CurrentState);
        }

        public void GoToNextState()
        {
            CurrentState++;

            //That means game restart, so skip the initial state
            if (CurrentState >= GameFlowState.StatesCount)
            {
                CurrentState = GameFlowState.PiecePlacement;
            }
            UpdateStateInternal();
            OnStateSwitched?.Invoke(CurrentState);
        }

        public void SwitchToNextPlayer()
        {
            var nextPlayer = _currentPlayer.Color + 1;
            if (nextPlayer >= PlayerColor.PlayersCount)
                nextPlayer = 0;

            _currentPlayer = _playerDataService.GetPlayer(nextPlayer);

            OnPlayerBeginTurn?.Invoke(_currentPlayer);
        }

        private void UpdateStateInternal()
        {
            switch (CurrentState)
            {
                case GameFlowState.PiecePlacement:
                    var randomColor = (PlayerColor)UnityEngine.Random.Range(0, (int)PlayerColor.PlayersCount);
                    _currentPlayer = _playerDataService.GetPlayer(randomColor);
                    _instancesManager.ShowPlayerAvailablePieces(_currentPlayer);
                    OnPlayerBeginTurn?.Invoke(_currentPlayer);
                    break;

                case GameFlowState.DynamicMode:
                    break;
                case GameFlowState.GameFinished:
                    break;
            }
        }
    }
}
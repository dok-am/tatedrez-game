﻿using System;
using Tatedrez.Data;
using Tatedrez.Data.Interfaces;
using Tatedrez.Services.GameFlow.Interfaces;
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

        public GameFlowService(IPlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;

            var randomColor = (PlayerColor)UnityEngine.Random.Range(0, (int)PlayerColor.PlayersCount);
            _currentPlayer = _playerDataService.GetPlayer(randomColor);

            CurrentState = GameFlowState.Initial;
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

        }
    }
}
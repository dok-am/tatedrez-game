using System;
using Tatedrez.Application;
using Tatedrez.Services.GameFlow.Interfaces;
using Tatedrez.UI.Interfaces;
using UnityEngine;

namespace Tatedrez.UI
{
    public class UIViewController
    {
        public event Action RequestStartGame;

        private IUIView _view;

        public UIViewController(GameplaySceneBinder sceneBinder, IGameFlowService gameFlowService)
        {
            _view = sceneBinder.UIView;
            _view.OnActionButtonClicked += OnActionButtonClicked;

            gameFlowService.OnStateSwitched += OnGameStateSwitched;
            gameFlowService.OnPlayerBeginTurn += OnPlayerBeginTurn;
        }

        private void OnActionButtonClicked()
        {
            RequestStartGame?.Invoke();
        }

        private void OnPlayerBeginTurn(Data.Interfaces.IPlayer player)
        {
            Color playerColor = player.Color == Data.Enums.PlayerColor.White ? Color.white : Color.black;
            string playerName = player.Color.ToString();
            _view.SetStatusText($"{playerName}'s turn", playerColor);
        }

        private void OnGameStateSwitched(Services.GameFlow.GameFlowState state)
        {
            switch (state)
            {
                case Services.GameFlow.GameFlowState.Initial:
                    _view.SetStatusText("Tatedrez", Color.black);
                    _view.SetActionButtonText("Start game");
                    _view.ShowActionButton(true);
                    _view.ShowStatusText(true);
                    break;

                case Services.GameFlow.GameFlowState.PiecePlacement:
                case Services.GameFlow.GameFlowState.DynamicMode:
                    _view.ShowActionButton(false);
                    break;

                case Services.GameFlow.GameFlowState.GameFinished:
                    _view.ShowActionButton(true);
                    break;
            }
        }
    }
}
using System;
using Tatedrez.Services.BoardService.Interface;
using Tatedrez.Services.GameFlow.Interfaces;
using Tatedrez.UI;
using Tatedrez.View.BoardView;
using VContainer;
using VContainer.Unity;

namespace Tatedrez.Application
{
    public class GameplayEntryPoint : IInitializable, IDisposable
    {
        [Inject] private IBoardService _boardService;
        [Inject] private BoardViewController _boardViewController;
        [Inject] private IGameFlowService _gameFlowService;
        [Inject] private UIViewController _uiViewController;

        public void Initialize()
        {
            _boardViewController.BuildBoard(_boardService.Board);
            _uiViewController.RequestStartGame += _gameFlowService.GoToNextState;

            _gameFlowService.StartGameFlow();
        }

        public void Dispose()
        {
            _uiViewController.RequestStartGame -= _gameFlowService.GoToNextState;
        }
    }
}

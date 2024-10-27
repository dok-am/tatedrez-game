using Tatedrez.Services.BoardService.Interface;
using Tatedrez.View.BoardView;
using VContainer;
using VContainer.Unity;

namespace Tatedrez.Application
{
    public class GameplayEntryPoint : IInitializable
    {
        [Inject] private IBoardService _boardService;
        [Inject] private BoardViewController _boardViewController;

        public void Initialize()
        {
            _boardViewController.BuildBoard(_boardService.Board);
        }
    }
}

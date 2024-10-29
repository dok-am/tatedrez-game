using Tatedrez.Configs;
using Tatedrez.UI;
using Tatedrez.UI.Interfaces;
using Tatedrez.View.BoardView;
using Tatedrez.View.PieceView;
using Tatedrez.View.PieceView.Interfaces;
using UnityEngine;

namespace Tatedrez.Application
{
    public class GameplaySceneBinder : MonoBehaviour
    {
        public PlayerConfig[] PlayersConfigs => _playersConfigs;
        public GameConfig GameConfig => _gameConfig;
        public BoardCellView BoardCellPrefab => _boardCellPrefab;
        public Sprite BlackBoardCellSprite => _blackBoardCellSprite; 
        public Sprite WhiteBoardCellSprite  => _whiteBoardCellSprite;
        public IUIView UIView => _uiView;
        public PieceView PiecePrefab => _piecePrefab;

        [Header("Configs")]
        [SerializeField] private PlayerConfig[] _playersConfigs;
        [SerializeField] private GameConfig _gameConfig;

        [Header("Prefabs")]
        [SerializeField] private BoardCellView _boardCellPrefab;
        [SerializeField] private PieceView _piecePrefab;

        [Header("Visuals")]
        [SerializeField] private Sprite _blackBoardCellSprite;
        [SerializeField] private Sprite _whiteBoardCellSprite;

        [Header("UI")]
        [SerializeField] private UIView _uiView;

    }
}
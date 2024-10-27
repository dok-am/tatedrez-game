﻿using Tatedrez.Configs;
using Tatedrez.View.BoardView;
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

        [Header("Configs")]
        [SerializeField] private PlayerConfig[] _playersConfigs;
        [SerializeField] private GameConfig _gameConfig;

        [Header("Prefabs")]
        [SerializeField] private BoardCellView _boardCellPrefab;

        [Header("Visuals")]
        [SerializeField] private Sprite _blackBoardCellSprite;
        [SerializeField] private Sprite _whiteBoardCellSprite;

    }
}
using System.Collections.Generic;
using Tatedrez.Application;
using Tatedrez.Data.Enums;
using Tatedrez.Data.Interfaces;
using Tatedrez.Services.Configs.Interfaces;
using Tatedrez.Services.Instances.Interfaces;
using Tatedrez.View.BoardView;
using Tatedrez.View.PieceView.Interfaces;
using UnityEngine;

namespace Tatedrez.Services.Instances
{
    public class InstancesManager : IInstancesManager
    {
        private GameObject _pieceInstancePrefab;
        private IConfigsService _configsService;
        private BoardViewController _boardViewController;

        private Dictionary<PlayerColor, Dictionary<PieceType, IPieceView>> _allPieces = new((int)PlayerColor.PlayersCount);
        private List<IPieceView> _currentAvailablePieces = new((int)PieceType.TypesCount);

        public InstancesManager(GameplaySceneBinder sceneBinder, 
            IConfigsService configsService, 
            BoardViewController boardViewController)
        {
            _pieceInstancePrefab = sceneBinder.PiecePrefab.gameObject;
            _configsService = configsService;
            _boardViewController = boardViewController;
        }

        public void ShowPlayerAvailablePieces(IPlayer player)
        {
            ClearCurrentPlayerPieces();

            if (_allPieces.TryGetValue(player.Color, out var playersPiecesViews))
            {
                foreach(var pieceData in player.FreePieces)
                {
                    _currentAvailablePieces.Add(playersPiecesViews[pieceData.Type]);
                }                
            } 
            else
            {
                SpawnPlayerPieces(player);
            }
            
            foreach(var piece in _currentAvailablePieces)
            {
                piece.Enable(true);
            }
        }

        private void SpawnPlayerPieces(IPlayer player)
        {
            Dictionary<PieceType, IPieceView> newPieces = new((int)PieceType.TypesCount);

            float delta = _boardViewController.BoardTotalSize / player.FreePieces.Count;
            float halfBoardSize = _boardViewController.BoardTotalSize / 2.0f;
            float beginPositionX = -halfBoardSize + _boardViewController.CellSize / 2.0f;
            float beginPositionY = -(halfBoardSize + _boardViewController.CellSize / 1.5f);
            Vector2 position = new Vector2(beginPositionX, beginPositionY);

            foreach (var pieceData in player.FreePieces)
            {
                IPieceView pieceView = GameObject.Instantiate(_pieceInstancePrefab, position, Quaternion.identity)
                    .GetComponent<IPieceView>();

                pieceView.SetSprite(_configsService.GetConfigForPiece(player.Color, pieceData.Type).Sprite);
                newPieces.Add(pieceData.Type, pieceView);

                _currentAvailablePieces.Add(pieceView);
                position.x += delta;
            }

            _allPieces.Add(player.Color, newPieces);
        }

        private void ClearCurrentPlayerPieces()
        {
            foreach(var piece in _currentAvailablePieces)
            {
                piece.Enable(false);
            }
            _currentAvailablePieces.Clear();
        }
        
    }
}
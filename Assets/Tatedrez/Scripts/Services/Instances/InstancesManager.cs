using System.Collections.Generic;
using Tatedrez.Application;
using Tatedrez.Data.Enums;
using Tatedrez.Data.Interfaces;
using Tatedrez.Services.Configs.Interfaces;
using Tatedrez.Services.Instances.Interfaces;
using Tatedrez.View.PieceView.Interfaces;
using UnityEngine;

namespace Tatedrez.Services.Instances
{
    public class InstancesManager : IInstancesManager
    {
        private GameObject _pieceInstancePrefab;
        private IConfigsService _configsService;

        private Dictionary<PlayerColor, Dictionary<PieceType, IPieceView>> _allPieces = new((int)PlayerColor.PlayersCount);
        private List<IPieceView> _currentAvailablePieces = new((int)PieceType.TypesCount);

        public InstancesManager(GameplaySceneBinder sceneBinder, IConfigsService configsService)
        {
            _pieceInstancePrefab = sceneBinder.PiecePrefab.gameObject;
            _configsService = configsService;
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

            foreach (var pieceData in player.FreePieces)
            {
                IPieceView pieceView = GameObject.Instantiate(_pieceInstancePrefab).GetComponent<IPieceView>();
                pieceView.SetSprite(_configsService.GetConfigForPiece(player.Color, pieceData.Type).Sprite);
                newPieces.Add(pieceData.Type, pieceView);

                _currentAvailablePieces.Add(pieceView);
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
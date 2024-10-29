using Tatedrez.Services.BoardService;
using Tatedrez.Services.BoardService.Interface;
using Tatedrez.Services.Configs;
using Tatedrez.Services.Configs.Interfaces;
using Tatedrez.Services.GameFlow;
using Tatedrez.Services.GameFlow.Interfaces;
using Tatedrez.Services.Instances;
using Tatedrez.Services.Instances.Interfaces;
using Tatedrez.Services.Players;
using Tatedrez.Services.Players.Interfaces;
using Tatedrez.UI;
using Tatedrez.UI.Interfaces;
using Tatedrez.View.BoardView;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tatedrez.Application
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameplaySceneBinder _sceneBinder;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_sceneBinder);

            builder.Register<IConfigsService, ConfigsService>(Lifetime.Singleton);

            builder.Register<IBoardService, BoardService>(Lifetime.Scoped);
            builder.Register<IPlayerDataService, PlayerDataService>(Lifetime.Scoped);
            builder.Register<IGameFlowService, GameFlowService>(Lifetime.Scoped);
            builder.Register<BoardViewController>(Lifetime.Scoped);
            builder.Register<IInstancesManager, InstancesManager>(Lifetime.Scoped);

            builder.Register<UIViewController>(Lifetime.Scoped);

            builder.RegisterEntryPoint<GameplayEntryPoint>();
        }
    }
}

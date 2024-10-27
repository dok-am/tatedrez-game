using Tatedrez.Services.Configs;
using Tatedrez.Services.Configs.Interfaces;
using Tatedrez.Services.Players;
using Tatedrez.Services.Players.Interfaces;
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

            builder.Register<IPlayerDataService, PlayerDataService>(Lifetime.Scoped);

            builder.RegisterEntryPoint<GameplayEntryPoint>();
        }
    }
}

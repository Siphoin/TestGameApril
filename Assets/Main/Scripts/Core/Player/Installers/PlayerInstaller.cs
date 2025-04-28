using System.Collections;
using TestGame.HealthSystem;
using TestGame.Player;
using UnityEngine;
using Zenject;

namespace TestGame.Core.Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private HealthComponent _playerHealthComponent;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerMovementController>().To<PlayerMovementController>().FromInstance(_playerMovementController);
            Container.Bind<IHealthComponent>().To<HealthComponent>().FromInstance(_playerHealthComponent);
        }
    }
}
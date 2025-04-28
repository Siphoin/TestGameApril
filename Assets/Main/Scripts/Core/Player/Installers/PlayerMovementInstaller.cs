using System.Collections;
using TestGame.Configs.Player;
using UnityEngine;
using Zenject;

namespace TestGame.Core.Player.Installers
{
    public class PlayerMovementInstaller : MonoInstaller
    {

        [SerializeField] private PlayerMovementSettings _playerMovementSettings;

        public override void InstallBindings()
        {
            Container.Bind<PlayerMovementSettings>()
                .FromScriptableObject(_playerMovementSettings)
                .AsSingle();
        }
    }
}
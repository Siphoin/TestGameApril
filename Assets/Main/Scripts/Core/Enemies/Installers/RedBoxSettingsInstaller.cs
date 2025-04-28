using TestGame.Configs.RedBoxConfigs;
using UnityEngine;
using Zenject;

namespace TestGame.Core.Enemies.Installers
{
    public class RedBoxSettingsInstaller : MonoInstaller
    {

        [SerializeField] private RedBoxSettings _settings;

        public override void InstallBindings()
        {
            Container.Bind<RedBoxSettings>()
                .FromScriptableObject(_settings)
                .AsSingle();
        }
    }
}
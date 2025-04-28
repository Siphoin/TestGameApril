using UnityEngine;
using Zenject;

namespace TestGame.Core.Handlers.Installers
{
    public class LevelHandlerInstaller : MonoInstaller
    {

        [SerializeField] private LevelHandler _levelHandler;

        public override void InstallBindings()
        {
            Container.Bind<ILevelHandler>().To<LevelHandler>().FromInstance(_levelHandler);
        }
    }
}
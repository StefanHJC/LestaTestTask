using UnityEngine;
using Zenject;
using Core.Blocks.Factories;

namespace Installers
{
    public class BBlockFactoryInstaller : MonoInstaller
    {
        [SerializeField] private BBlockFactory _factory;

        public override void InstallBindings()
        {
            Container.
                Bind<BBlockFactory>().
                FromInstance(_factory).
                AsSingle().
                NonLazy();
        }
    }
}
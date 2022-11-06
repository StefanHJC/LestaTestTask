using UnityEngine;
using Zenject;
using Core.Blocks.Factories;

namespace Installers
{
    public class BBlockFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<BBlockFactory>().
                FromNew().
                AsSingle().
                NonLazy();
        }
    }
}
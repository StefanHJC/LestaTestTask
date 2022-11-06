using UnityEngine;
using Zenject;
using Core.Blocks.Factories;

namespace Installers
{
    public class CBlockFactoryInstaller : MonoInstaller
    {
        [SerializeField] private CBlockFactory _factory;

        public override void InstallBindings()
        {
            Container.
                Bind<CBlockFactory>().
                FromNew().
                AsSingle().
                NonLazy();
        }
    }
}
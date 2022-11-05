using UnityEngine;
using Zenject;
using Core.Blocks.Factories;

namespace Installers
{ 
public class ABlockFactoryInstaller : MonoInstaller
{
        [SerializeField] private ABlockFactory _factory;

        public override void InstallBindings()
        {
            Container.
                Bind<ABlockFactory>().
                FromInstance(_factory).
                AsSingle().
                NonLazy();
        }
    }
}
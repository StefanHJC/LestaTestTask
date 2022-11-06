using UnityEngine;
using Zenject;
using Core.Blocks.Factories;

namespace Installers
{ 
public class ABlockFactoryInstaller : MonoInstaller
{
        public override void InstallBindings()
        {
            Container.
                Bind<ABlockFactory>().
                FromNew().
                AsSingle().
                NonLazy();
        }
    }
}
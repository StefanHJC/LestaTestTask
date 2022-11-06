using UnityEngine;
using Zenject;
using Core.Blocks.Factories;

namespace Installers
{ 
public class ABlockFactoryInstaller : MonoInstaller
{
        [SerializeField] private Sprite _aBlockSprite;

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
using UnityEngine;
using Zenject;
using Core.Blocks.Factories;

namespace Installers
{
    public class BBlockFactoryInstaller : MonoInstaller
    {
        [SerializeField] private Sprite _BBlockSprite;

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
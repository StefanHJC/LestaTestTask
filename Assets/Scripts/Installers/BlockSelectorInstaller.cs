using UnityEngine;
using Zenject;

namespace Installers
{
    public class BlockSelectorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<UI.BlockSelector>().
                FromNew().
                AsSingle();
        }
    }
}
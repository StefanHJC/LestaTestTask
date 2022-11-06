using UnityEngine;
using Zenject;

namespace Installers
{
    public class MouseInputServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<MouseInputService>().
                FromNew().
                AsSingle().
                NonLazy();
        }
    }
}
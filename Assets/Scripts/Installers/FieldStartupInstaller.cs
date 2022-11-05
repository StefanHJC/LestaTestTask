using UnityEngine;
using Zenject;

public class FieldStartupInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<Core.FieldStartup>().
            FromNew().
            AsSingle().
            NonLazy();
    }
}
using UnityEngine;
using Zenject;

public class MediatorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<UI.Mediator>().
            FromNew().
            AsSingle();
    }
}
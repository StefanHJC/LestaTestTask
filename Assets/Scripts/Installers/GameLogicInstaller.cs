using UnityEngine;
using Zenject;

public class GameLogicInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<Core.GameLogic>().
            FromNew().
            AsSingle();
    }
}
using UnityEngine;
using Zenject;

public class GameLogicInstaller : MonoInstaller
{
    [SerializeField] private Core.GameLogic _gameLogic;
    public override void InstallBindings()
    {
        Container.
            Bind<Core.GameLogic>().
            FromInstance(_gameLogic)
            .AsSingle();
    }
}
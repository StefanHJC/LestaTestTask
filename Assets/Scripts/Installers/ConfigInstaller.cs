using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    [SerializeField] private Config _config;

    public override void InstallBindings()
    {
        Container.
            Bind<Config>().
            FromInstance(_config).
            AsSingle();
    }
}
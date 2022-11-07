using UnityEngine;
using Zenject;
using UI;

namespace Installers
{
    public class BlockSelectorInstaller : MonoInstaller
    {
        [SerializeField] private BlockSelector _blockSelector;

        public override void InstallBindings()
        {
            var instance = Container.InstantiatePrefabForComponent<BlockSelector>(_blockSelector);

            Container.
                Bind<BlockSelector>().
                FromInstance(instance).
                AsSingle();
        }
    }
}
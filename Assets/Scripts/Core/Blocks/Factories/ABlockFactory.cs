using UnityEngine;
using Zenject;

namespace Core.Blocks.Factories
{
    public class ABlockFactory : IBlockFactory
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private Config _config;

        private MovableBlock dummyBlock => _config.DummyBlock;
        private Sprite blockSprite => _config.ABlockSprite;
        private BlockType blockType => BlockType.ABlock;

        public virtual IBlock Create()
        {
            GameObject blockGO = _diContainer.InstantiatePrefab(dummyBlock.gameObject);
            IBlock block = blockGO.GetComponent<IBlock>();
            block.Init(blockType, blockSprite);

            return block;
        }
    }
}
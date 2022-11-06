using UnityEngine;
using Zenject;

namespace Core.Blocks.Factories
{
    public abstract class MovableBlocksFactory : IBlockFactory
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private Config _config;

        private MovableBlock dummyBlock => _config.DummyBlock;

        protected Sprite BlockSprite;
        protected BlockType BlockType;

        public virtual IBlock Create()
        {
            GameObject blockGO = _diContainer.InstantiatePrefab(dummyBlock.gameObject);
            IBlock block = blockGO.GetComponent<IBlock>(); 
            block.Init(BlockType, BlockSprite);

            return dummyBlock;
        }

        private void OnValidate()
        {
            if (BlockSprite == null)
                throw new System.InvalidOperationException("Block sprite not setted");
        }
    }
}
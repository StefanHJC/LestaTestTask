using UnityEngine;
using Zenject;

namespace Core.Blocks.Factories
{
    public abstract class MovableBlocksFactory : IBlockFactory
    {
        [Inject] private DiContainer _diContainer;

        private MovableBlock dummyBlock => Config.DummyBlock;
        
        [Inject] protected Config Config;

        protected Sprite BlockSprite;
        protected BlockType BlockType;

        public virtual IBlock Create()
        {
            GameObject blockGO = _diContainer.InstantiatePrefab(dummyBlock.gameObject);
            IBlock block = blockGO.GetComponent<IBlock>(); 
            block.Init(BlockType, BlockSprite);

            return dummyBlock;
        }
    }
}
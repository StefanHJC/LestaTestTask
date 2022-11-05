using UnityEngine;

namespace Core.Blocks.Factories
{
    public abstract class MovableBlocksFactory : MonoBehaviour, IBlockFactory
    {
        [SerializeField] private MovableBlock _dummyBlock;
        [SerializeField] private Sprite _blockSprite;
        [SerializeField] private BlockType _blockType;

        public virtual IBlock Create()
        {
            IBlock block;

            block = Instantiate(_dummyBlock);
            block.Init(_blockType, _blockSprite);

            return block;
        }

        private void OnValidate()
        {
            if (_blockSprite == null)
                throw new System.InvalidOperationException("Block sprite not setted");
        }
    }
}
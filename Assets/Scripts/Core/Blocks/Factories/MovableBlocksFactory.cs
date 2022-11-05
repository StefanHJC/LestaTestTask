using UnityEngine;

namespace Core.Blocks.Factories
{
    public class MovableBlocksFactory : MonoBehaviour, IBlockFactory
    {
        [SerializeField] private Sprite _blockSprite;
        [SerializeField] private MovableBlock _dummyBlock;
        [SerializeField] private BlockType _blockType;

        public IBlock Create()
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
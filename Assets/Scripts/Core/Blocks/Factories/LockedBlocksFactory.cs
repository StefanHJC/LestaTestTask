using UnityEngine;

namespace Core.Blocks.Factories
{
    public class LockedBlocksFactory : IBlockFactory
    {
        [SerializeField] private Sprite _blockSprite;

        public IBlock Create()
        {
            throw new System.NotImplementedException();
        }
    }
}
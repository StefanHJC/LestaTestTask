using UnityEngine;

namespace Core.Blocks
{
    public interface IBlock
    {
        BlockType Type { get; }

        void Init(BlockType type, Sprite sprite);
    }
}
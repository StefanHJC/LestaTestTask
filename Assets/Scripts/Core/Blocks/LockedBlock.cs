using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Blocks
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class LockedBlock : MonoBehaviour, IBlock
    {
        BlockType IBlock.Type => BlockType.Locked;

        public void Init(BlockType type, Sprite sprite)
        {
            throw new System.NotImplementedException();
        }

        void IBlock.Init(BlockType type, Sprite sprite)
        {
            throw new System.NotImplementedException();
        }
    }
}
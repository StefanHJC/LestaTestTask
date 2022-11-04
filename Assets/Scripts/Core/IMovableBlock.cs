using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public interface IMovableBlock : IPointerUpHandler
    {
        BlockType Type { get; }

        void Move();
    }
}
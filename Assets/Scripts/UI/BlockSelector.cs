using UnityEngine;
using Core.Blocks;

namespace UI
{
    public class BlockSelector
    {
        public void Focus(MovableBlock block)
        {
            Debug.Log("Highlight");
        }

        public void Select(MovableBlock block)
        {
            Debug.Log("Select");
        }
    }
}
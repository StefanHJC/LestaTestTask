using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public struct BlockArea
    {
        [SerializeField] private List<BackgroundCell> _area;
        [SerializeField] private BlockType _type;

        public List<BackgroundCell> Area => _area;
        public BlockType Type => _type;
    }
}
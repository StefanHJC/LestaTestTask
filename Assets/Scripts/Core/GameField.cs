using UnityEngine;

namespace Core
{
    public class GameField : MonoBehaviour
    {
        private int[][] _gameFieldBlocks; 
    }

    public enum BlockType
    {
        Locked = 1,
        ABlock = 2,
        BBlock = 3,
        CBlock = 4
    }
}
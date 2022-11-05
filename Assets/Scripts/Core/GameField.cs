using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameField : MonoBehaviour
    {
        [Tooltip("Cell size in pixels")]
        [SerializeField] private int _cellSize = 64;

        [Inject] private FieldStartup _fieldStartup;

        private void Start()
        {
            _fieldStartup.PrepareField(this);
        }
    }

    public enum BlockType
    {
        Empty = 0,
        Locked = 1,
        ABlock = 2,
        BBlock = 3,
        CBlock = 4
    }

}
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Core.Blocks;
using Zenject;

namespace Core
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private List<BlockArea> _areas;

        [Inject] private FieldStartup _fieldStartup;

        private List<MovableBlock> _blocksOnGameField = new List<MovableBlock>();

        [System.Serializable]
        public struct BlockArea
        {
            [SerializeField] private List<BackgroundCell> _area;
            [SerializeField] private Sprite _areaLabel;
            [SerializeField] private BlockType _type;

            public List<BackgroundCell> Cells => _area;
            public Sprite AreaLabel => _areaLabel;
            public BlockType Type => _type;
        }

        public List<BlockArea> BlockAreas => _areas;

        public event UnityAction BlockMovedToCorrectColumn;
        public event UnityAction BlockMovedFromCorrectColumn;
        public event UnityAction AllBlocksInCorrectColumns;

        public void TryMoveBlock(MovableBlock block, Vector2 position)
        {
            int maxAllowedMoveDistance = 1;

            if (Vector2.Distance(block.transform.position, position) <= maxAllowedMoveDistance)
                MoveBlock(block, position);

            OnBlockMoved();
        }

        private void MoveBlock(MovableBlock block, Vector2 position)
        {
            block.MoveTo(position);
        }

        private void OnBlockMoved()
        {

        }

        private void Start()
        {
            PrepareField();
        }

        private void PrepareField()
        {
            List<Vector2> spawnableCoordinates = GetSpawnableCoordinates();
            List<IBlock> blocks = _fieldStartup.GetMovableBlocks(spawnableCoordinates.Count);

            for(int i = 0; i < spawnableCoordinates.Count; i++)
            {
                var movableBlock = (MovableBlock)blocks[i];
                movableBlock.transform.position = spawnableCoordinates[i];
                movableBlock.transform.SetParent(transform);
                _blocksOnGameField.Add(movableBlock);
            }
        }

        private List<Vector2> GetSpawnableCoordinates()
        {
            List<Vector2> spawnableCoordinates = new List<Vector2>();

            foreach (var area in _areas)
                foreach(var cell in area.Cells)
                    spawnableCoordinates.Add(cell.transform.position);

            return spawnableCoordinates;
        }
    }

    public enum BlockType
    {
        Locked = 0,
        ABlock = 1,
        BBlock = 2,
        CBlock = 3
    }
}
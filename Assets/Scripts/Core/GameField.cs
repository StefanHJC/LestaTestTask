using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Core.Blocks;
using Zenject;

namespace Core
{
    public class GameField : MonoBehaviour
    {
        [Header("Block columns")]
        [SerializeField] private List<BackgroundCell> _aBlockColumn;
        [SerializeField] private List<BackgroundCell> _bBlockColumn;
        [SerializeField] private List<BackgroundCell> _cBlockColumn;

        [SerializeField] private List<BlockArea> _areas;

        [Space]
        [Header("Block column labels")]
        [SerializeField] private Sprite _aColumnLabel;
        [SerializeField] private Sprite _bColumnLabel;
        [SerializeField] private Sprite _cColumnLabel;

        [Inject] private FieldStartup _fieldStartup;

        private List<MovableBlock> _blocksOnGameField = new List<MovableBlock>();


        [System.Serializable]
        private struct BlockArea
        {
            [SerializeField] private List<BackgroundCell> _area;
            [SerializeField] private BlockType _type;

            public List<BackgroundCell> Area => _area;
            public BlockType Type => _type;
        }

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
            SetColumnLabels();
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

        private void SetColumnLabels()
        {
            Instantiate(_aColumnLabel, new Vector2(_aBlockColumn[0].transform.position.x, 1), Quaternion.identity, transform);
            Instantiate(_bColumnLabel, new Vector2(_bBlockColumn[0].transform.position.x, 1), Quaternion.identity, transform);
            Instantiate(_cColumnLabel, new Vector2(_cBlockColumn[0].transform.position.x, 1), Quaternion.identity, transform);
        }

        private List<Vector2> GetSpawnableCoordinates()
        {
            List<Vector2> spawnableCoordinates = new List<Vector2>();

            foreach (var cell in _aBlockColumn)
                spawnableCoordinates.Add(cell.transform.position);

            foreach (var cell in _bBlockColumn)
                spawnableCoordinates.Add(cell.transform.position);

            foreach (var cell in _cBlockColumn)
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
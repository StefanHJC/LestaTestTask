using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Core.Blocks;
using System.Linq;
using Zenject;

namespace Core
{
    [RequireComponent(typeof(GameLogic))]
    public class GameField : MonoBehaviour
    {
        [SerializeField] private List<BlockArea> _areas;

        [Inject] private FieldStartuper _fieldStartup;
        [Inject] private Config _config;

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

        public IReadOnlyList<MovableBlock> BlocksOnGameField => _blocksOnGameField;
        public List<BlockArea> BlockAreas => _areas;

        public event UnityAction<MovableBlock> BlockMoved;

        public void TryMoveBlock(MovableBlock block, Vector2 position)
        {
            int maxAllowedMoveDistance = 1;

            if (Vector2.Distance(block.transform.position, position) <= maxAllowedMoveDistance)
                MoveBlock(block, position);

            BlockMoved?.Invoke(block);
        }

        private void MoveBlock(MovableBlock block, Vector2 position)
        {
            block.MoveTo(position);
        }

        private void Start()
        {
            PrepareField();
            SetAreaLabels();
        }

        private void PrepareField()
        {
            List<Vector2> spawnableCoordinates = GetSpawnableCoordinates();
            _blocksOnGameField = _fieldStartup.GetMovableBlocks();

            for(int i = 0; i < spawnableCoordinates.Count; i++)
            {
                _blocksOnGameField[i].transform.position = spawnableCoordinates[i];
                _blocksOnGameField[i].transform.SetParent(transform);
            }
        }

        private void SetAreaLabels()
        {
            foreach (var area in _areas)
            {
                BackgroundCell firstCell = area.Cells.Where(cell => cell.transform.position.y == 0).FirstOrDefault();
                Vector2 labelPosition = (Vector2)firstCell.transform.position + Vector2.up;
                GameObject dummyLabel = Instantiate(_config.DummyLabel);

                var renderer = dummyLabel.GetComponent<SpriteRenderer>();
                dummyLabel.transform.position = labelPosition;
                renderer.sprite = area.AreaLabel;
                dummyLabel.transform.SetParent(transform);
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
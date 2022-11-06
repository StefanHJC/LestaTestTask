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

        [Space]
        [Header("Block column labels")]
        [SerializeField] private Sprite _aColumnLabel;
        [SerializeField] private Sprite _bColumnLabel;
        [SerializeField] private Sprite _cColumnLabel;

        [Inject] private FieldStartup _fieldStartup;

        //public Vector2Int MapSize => (Vector2Int)_tilemap.size;

        public event UnityAction BlockMovedToCorrectColumn;
        public event UnityAction BlockMovedFromCorrectColumn;
        public event UnityAction AllBlocksInCorrectColumns;

        private void Start()
        {
            PrepareField();
            SetColumnLabels();
        }

        private void OnValidate()
        {
        }

        private void OnBlockMoved()
        {

        }

        private void PrepareField()
        {
            List<Vector2> spawnableCoordinates = GetSpawnableCoordinates();
            List<IBlock> blocks = _fieldStartup.GetMovableBlocks(spawnableCoordinates.Count);

            for(int i = 0; i < spawnableCoordinates.Count; i++)
            {
                var movableBlock = (MovableBlock)blocks[i];
                movableBlock.transform.position = spawnableCoordinates[i];
                //movableBlock.transform.SetParent(transform);
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
        Empty = 0,
        Locked = 1,
        ABlock = 2,
        BBlock = 3,
        CBlock = 4
    }

}
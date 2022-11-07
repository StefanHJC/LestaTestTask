using System.Linq;
using UnityEngine;
using Zenject;
using Core.Blocks;

namespace Core
{
    public class GameLogic : MonoBehaviour
    {
        [Inject] private GameField _gamefield;
        [Inject] private UI.Mediator _mediator;

        private int _areaCellsAmount;
        private int _blocksInRequiredPositionsAmount;

        public int AreaCellsAmount => _areaCellsAmount; 

        private void Start()
        {
            _gamefield.BlockMoved += OnBlockMoved;

            foreach (var area in _gamefield.BlockAreas)
                _areaCellsAmount += area.Cells.Count;
        }

        private void Win()
        {
            Application.Quit();
            Debug.Log("WIN");
        }

        private void OnBlockMoved(MovableBlock _)
        {
            _blocksInRequiredPositionsAmount = CheckForBlocksInRequiredPositions();

            if (_blocksInRequiredPositionsAmount == _areaCellsAmount)
                Win();

        }

        private int CheckForBlocksInRequiredPositions()
        {
            int blocksInRequiredPositions = 0;

            foreach (var block in _gamefield.BlocksOnGameField)
            {
                GameField.BlockArea areaByBlockType =
                    _gamefield.BlockAreas.
                    Where(area => area.Type == block.Type).
                    FirstOrDefault();

                foreach(var cell in areaByBlockType.Cells)
                {
                    if (cell.transform.position == block.transform.position)
                    {
                        blocksInRequiredPositions++;
                    }
                }
            }
            return blocksInRequiredPositions;
        }
    }
}
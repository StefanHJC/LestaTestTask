using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Core.Blocks;
using UnityEngine.Events;

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
            Time.timeScale = 0;
            Debug.Log("WIN");
            //_mediator.ShowGameEndMessage("You are win!");
        }

        private void Lose()
        {
            Time.timeScale = 0;

         //   _mediator.ShowGameEndMessage("You are lose!");
        }

        private void OnBlockMoved(MovableBlock block)
        {
            _blocksInRequiredPositionsAmount = CheckForBlocksInRequiredPositions();

            Debug.Log(_blocksInRequiredPositionsAmount);

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
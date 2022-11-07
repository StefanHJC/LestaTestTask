using UnityEngine;
using Zenject;
using Core.Blocks;

namespace Core
{
    public class GameLogic
    {
        [Inject] private GameField _gameField;
        [Inject] private UI.Mediator _mediator;

        private int _areaCellsAmount;
        private int _blocksInRequiredPositionsAmount;

        public int AreaCellsAmount => _areaCellsAmount;

        public GameLogic()
        {
            _gameField.BlockMoved += OnBlockMoved;
            Debug.Log("SUBSCRIBED");
            foreach (var area in _gameField.BlockAreas)
                _areaCellsAmount += area.Cells.Count;
        }

        private void OnBlockMoved(MovableBlock block)
        {

        }
    }
}
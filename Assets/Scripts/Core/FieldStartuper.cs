using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Core.Blocks.Factories;
using Core.Blocks;
using System.Linq;

namespace Core
{
    public class FieldStartuper
    {
        [Inject] private ABlockFactory _aBlockFactory;
        [Inject] private BBlockFactory _bBlockFactory;
        [Inject] private CBlockFactory _cBlockFactory;
        [Inject] private GameField _gameField;

        private Dictionary<BlockType, int> _accumulatedBlocks = new Dictionary<BlockType, int>();

        public List<IBlock> GetMovableBlocks()
        {
            List<IBlock> blocks = new List<IBlock>();
            bool isAccumulated = false;

            foreach (var area in _gameField.BlockAreas)
                _accumulatedBlocks.Add(area.Type, 0);

            while (isAccumulated != true)
            {
                IBlock randomBlock = GetRandomBlock();

                GameField.BlockArea areaByBlockType = 
                    _gameField.BlockAreas.
                    Where(area => area.Type == randomBlock.Type).
                    FirstOrDefault();

                if (_accumulatedBlocks[randomBlock.Type] < areaByBlockType.Cells.Count)
                {
                    blocks.Add(randomBlock);
                    _accumulatedBlocks[randomBlock.Type] += 1;
                }
                foreach (var area in _gameField.BlockAreas)
                {
                    if (area.Cells.Count == _accumulatedBlocks[area.Type])
                    {
                        isAccumulated = true;
                    }
                    else
                    {
                        isAccumulated = false;
                    }
                }
            }
            return blocks;
        }
        
        private IBlock GetRandomBlock() 
        {
            int type = Random.Range(0, 3); // TEMP

            switch (type)
            {
                case 0:
                    return _aBlockFactory.Create();
                case 1:
                    return _bBlockFactory.Create();
                case 2:
                    return _cBlockFactory.Create();
                default:
                    throw new System.InvalidOperationException();
            }
        }
    }
}
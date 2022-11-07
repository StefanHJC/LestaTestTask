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
        [Inject] private GameField _gamefield;

        private Dictionary<BlockType, int> _accumulatedBlocks = new Dictionary<BlockType, int>();

        public List<IBlock> GetMovableBlocks()
        {
            List<IBlock> blocks = new List<IBlock>();
            bool isAccumulated = false;

            foreach (var area in _gamefield.BlockAreas)
                _accumulatedBlocks.Add(area.Type, 0);

            while (isAccumulated != true)
            {

                BlockType blockTypeToSpawn = GetRandomBlockType();

                GameField.BlockArea areaByBlockType = 
                    _gamefield.BlockAreas.
                    Where(area => area.Type == blockTypeToSpawn).
                    FirstOrDefault();

                if (_accumulatedBlocks[blockTypeToSpawn] < areaByBlockType.Cells.Count)
                {
                    //Debug.Log($"ADDING {randomBlock.Type} CURRENT AMOUNT {_accumulatedBlocks[randomBlock.Type] + 1} TO {areaByBlockType.Type}");
                    IBlock randomBlock = GetBlock(blockTypeToSpawn);
                    blocks.Add(randomBlock);
                    _accumulatedBlocks[randomBlock.Type] += 1;
                }

                foreach (var area in _gamefield.BlockAreas)
                {
                    if (area.Cells.Count == _accumulatedBlocks[area.Type])
                    {
                        int test = _accumulatedBlocks[area.Type];
                        isAccumulated = true;
                    }
                    else
                    {
                        isAccumulated = false;
                        break;
                    }
                }
            }
            return blocks;
        }

        private IBlock GetBlock(BlockType type) 
        {
            switch (type)
            {
                case BlockType.ABlock:
                    return _aBlockFactory.Create();
                case BlockType.BBlock:
                    return _bBlockFactory.Create();
                case BlockType.CBlock:
                    return _cBlockFactory.Create();
                default:
                    throw new System.InvalidOperationException();
            }
        }

        private BlockType GetRandomBlockType()
        {
            int type = Random.Range(0, 3); // TEMP

            switch (type)
            {
                case 0:
                    return BlockType.ABlock;
                case 1:
                    return BlockType.BBlock;
                case 2:
                    return BlockType.CBlock;
                default:
                    throw new System.InvalidOperationException();
            }
        }
    }
}
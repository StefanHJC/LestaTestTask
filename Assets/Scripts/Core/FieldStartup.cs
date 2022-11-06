using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Core.Blocks.Factories;
using Core.Blocks;

namespace Core
{
    public class FieldStartup
    {
        [Inject] private ABlockFactory _aBlockFactory;
        [Inject] private BBlockFactory _bBlockFactory;
        [Inject] private CBlockFactory _cBlockFactory;

        public List<IBlock> GetMovableBlocks(int amount)
        {
            List<IBlock> blocks = new List<IBlock>();

            for (int i = 0; i < amount; i++)
                blocks.Add(GetRandomBlock());

            return blocks;
        }
        
        private IBlock GetRandomBlock() // TEMP
        {
            int type = Random.Range(1, 4);

            switch (type)
            {
                case 1:
                    return _aBlockFactory.Create();
                case 2:
                    return _bBlockFactory.Create();
                case 3:
                    return _cBlockFactory.Create();
                default:
                    throw new System.InvalidOperationException();
            }
        }
    }
}
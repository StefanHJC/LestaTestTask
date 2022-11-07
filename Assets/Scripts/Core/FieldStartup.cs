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
        [Inject] private Config _config;

        public List<IBlock> GetMovableBlocks(int amount)
        {
            List<IBlock> blocks = new List<IBlock>();

            for (int i = 0; i < amount; i++)
                blocks.Add(GetRandomBlock());

            return blocks;
        }
        
        private IBlock GetRandomBlock() // TEMP
        {
            int type = Random.Range(0, 3);

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
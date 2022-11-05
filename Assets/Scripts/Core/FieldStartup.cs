using UnityEngine;
using Zenject;
using Core.Blocks.Factories;
using Core.Blocks;

namespace Core
{
    public class FieldStartup : MonoBehaviour
    {
        [Inject] private ABlockFactory _aBlockFactory;
        [Inject] private BBlockFactory _bBlockFactory;
        [Inject] private CBlockFactory _cBlockFactory;

        public void PrepareField(GameField field)
        {

        }

        private void SetMovableBlocks()
        {

        }
        
        private IBlock GetRandomBlock() // TEMP
        {
            int type = Random.Range(1, 3);

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
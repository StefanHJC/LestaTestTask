using UnityEngine;
using Zenject;
using Core;

namespace Installers
{
    public class GameFieldInstaller : MonoInstaller
    {
        [SerializeField] private GameField _gameField;
        
        public override void InstallBindings()
        {
            Container.
                Bind<GameField>().
                FromInstance(_gameField).
                AsSingle().
                NonLazy();
        }
    } 
}
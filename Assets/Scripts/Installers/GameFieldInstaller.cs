using UnityEngine;
using Zenject;
using Core;

namespace Installers
{
    public class GameFieldInstaller : MonoInstaller
    {
        [SerializeField] private GameField _gameField;
        [SerializeField] private Vector2 _gameFieldPosition = Vector2.zero;
        
        public override void InstallBindings()
        {
            //GameField gameFieldInstance = Container.InstantiatePrefabForComponent<GameField>(_gameField, _gameFieldPosition, Quaternion.identity, null);

            Container.
                Bind<GameField>().
                FromInstance(_gameField).
                AsSingle().
                NonLazy();
        }
    } 
}
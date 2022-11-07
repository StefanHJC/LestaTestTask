using UnityEngine;
using Core.Blocks;
using Zenject;

public class MouseInputService
{
    [Inject] private UI.Mediator _mediator;
    [Inject] private Core.GameField _gameField;

    # nullable enable
    private MovableBlock? _selectedBlock; 

    public void OnSelectBlock(MovableBlock block)
    {
        _selectedBlock = block;
        _mediator.SelectBlock(block);
    }

    public void OnDeselectBlock()
    {
        _mediator.DeselectBlock(_selectedBlock);
        _selectedBlock = null;
    }

    public void OnFocusBlock(MovableBlock block)
    {
        _mediator.FocusBlock(block);
    }

    public void TryMoveSelectedBlock(Vector2 position)
    {
        if (_selectedBlock == null)
            return;

        _gameField.TryMoveBlock(_selectedBlock, position);
    }
}

using UnityEngine;
using Core.Blocks;
using Zenject;

public class MouseInputService
{
    [Inject] private UI.Mediator _mediator;

    # nullable enable
    private IBlock? _selectedBlock; 

    public void OnSelectBlock(MovableBlock block)
    {
        _selectedBlock = block;
        _mediator.SelectBlock(block);
    }

    public void OnDeselectBlock()
    {
        _selectedBlock = null;
    }

    public void OnFocusBlock(MovableBlock block)
    {
        _mediator.HighlightBlock(block);
    }

    public void TryMoveSelectedBlock()
    {

    }

    private void MoveSelectedBlock()
    {

    }
}

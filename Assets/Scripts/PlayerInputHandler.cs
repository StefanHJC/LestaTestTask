using UnityEngine;
using Core.Blocks;

public class PlayerInputHandler : MonoBehaviour
{
    # nullable enable
    private IBlock? _selectedBlock; 

    public void SelectBlock(IBlock block)
    {
        _selectedBlock = block;
    }

    public void DeselectBlock()
    {
        _selectedBlock = null;
    }
}

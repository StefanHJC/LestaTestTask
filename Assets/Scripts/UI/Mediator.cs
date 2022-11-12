using Zenject;

namespace UI
{
    public class Mediator
    {
        [Inject] private BlockSelector _blockSelector;

        public void SelectBlock(Core.Blocks.MovableBlock block) => _blockSelector.Select(block);
        public void FocusBlock(Core.Blocks.MovableBlock block) => _blockSelector.Focus(block);
        public void DeselectBlock(Core.Blocks.MovableBlock block) => _blockSelector.Deselect(block);
    }
}

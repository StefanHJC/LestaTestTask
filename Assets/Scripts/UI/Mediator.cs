using Zenject;

namespace UI
{
    public class Mediator
    {
        [Inject] private BlockSelector _blockSelector;
        //[Inject] private TimerBar _timerBar;
        //[Inject] private ArrowIndicator _arrowIndicator;
        //[Inject] private Menu _menu;

       // public void ToggleMenu() => _menu.Toggle();
       // public void CloseMenu() => _menu.Close();
        public void SelectBlock(Core.Blocks.MovableBlock block) => _blockSelector.Select(block);
        public void FocusBlock(Core.Blocks.MovableBlock block) => _blockSelector.Focus(block);
        public void DeselectBlock(Core.Blocks.MovableBlock block) => _blockSelector.Deselect(block);
    }
}
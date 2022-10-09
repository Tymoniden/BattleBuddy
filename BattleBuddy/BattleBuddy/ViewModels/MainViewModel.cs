using BattleBuddy.ViewModels;

namespace BattleBuddy.ViewModel
{
    public sealed class MainViewModel : Base.ViewModel
    {
        public MainViewModel(HotKeysPanelViewModel hotKeysPanelViewModel)
        {
            HotKeysPanelViewModel = hotKeysPanelViewModel ?? throw new System.ArgumentNullException(nameof(hotKeysPanelViewModel));
        }

        public HotKeysPanelViewModel HotKeysPanelViewModel { get; }

        public void Setup()
        {
            HotKeysPanelViewModel.Setup();
        }
    }
}

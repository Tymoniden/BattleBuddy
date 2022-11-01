using BattleBuddy.ViewModels;

namespace BattleBuddy.ViewModel
{
    public sealed class MainViewModel : Base.ViewModel
    {
        public MainViewModel(HotKeysPanelViewModel hotKeysPanelViewModel, ClientConnectionOverlayViewModel clientConnectionOverlayViewModel)
        {
            HotKeysPanelViewModel = hotKeysPanelViewModel ?? throw new System.ArgumentNullException(nameof(hotKeysPanelViewModel));
            ClientConnectionOverlayViewModel = clientConnectionOverlayViewModel ?? throw new System.ArgumentNullException(nameof(clientConnectionOverlayViewModel));
        }

        public HotKeysPanelViewModel HotKeysPanelViewModel { get; }

        public ClientConnectionOverlayViewModel ClientConnectionOverlayViewModel { get; }

        public async void Setup()
        {
            HotKeysPanelViewModel.Setup();
            await ClientConnectionOverlayViewModel.Setup();
        }
    }
}

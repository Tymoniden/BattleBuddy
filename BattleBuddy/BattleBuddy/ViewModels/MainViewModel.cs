using BattleBuddy.ViewModels;

namespace BattleBuddy.ViewModel
{
    public sealed class MainViewModel : Base.ViewModel
    {
        public MainViewModel(HotKeysPanelViewModel hotKeysPanelViewModel, ClientEndpointOverlayViewModel clientEndpointOverlayViewModel)
        {
            HotKeysPanelViewModel = hotKeysPanelViewModel ?? throw new System.ArgumentNullException(nameof(hotKeysPanelViewModel));
            ClientEndpointOverlayViewModel = clientEndpointOverlayViewModel ?? throw new System.ArgumentNullException(nameof(clientEndpointOverlayViewModel));
        }

        public HotKeysPanelViewModel HotKeysPanelViewModel { get; }

        public ClientEndpointOverlayViewModel ClientEndpointOverlayViewModel { get; }

        public async void Setup()
        {
            HotKeysPanelViewModel.Setup();
            await ClientEndpointOverlayViewModel.Setup();
        }
    }
}

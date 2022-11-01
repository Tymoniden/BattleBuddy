using BattleBuddy.ViewModel;
using BattleBuddy.ViewModels;
using SimpleInjector;

namespace BattleBuddy.Services
{
    public static class ContainerService
    {
        public static void SetupContainer(Container container)
        {
            container.RegisterSingleton<ViewModelFactory>();
            container.RegisterSingleton<IHotKeyService, HotKeyService>();
            container.RegisterSingleton<MainViewModel>();
            container.RegisterSingleton<HotKeysPanelViewModel>();
            container.RegisterSingleton<RosterDisplayViewModel>();
            container.RegisterSingleton<ClientConnectionOverlayViewModel>();
            container.RegisterSingleton<IHotKeyRegistrationService, HotKeyRegistrationService>();
            container.RegisterSingleton<IClientEndpointService, ClientEndpointService>();
            container.RegisterSingleton<INetworkService, NetworkService>();
            container.RegisterSingleton<IQRCodeService, QRCodeService>();
        }
    }
}

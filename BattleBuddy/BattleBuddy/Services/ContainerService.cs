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
            container.RegisterSingleton<MainViewModel>();
            container.RegisterSingleton<HotKeysPanelViewModel>();
            container.RegisterSingleton<RosterDisplayViewModel>();
            container.RegisterSingleton<ClientEndpointOverlayViewModel>();
            container.RegisterSingleton<IHotKeyService, HotKeyService>();
            container.RegisterSingleton<IHotKeyRegistrationService, HotKeyRegistrationService>();
            container.RegisterSingleton<IClientEndpointService, ClientEndpointService>();
            container.RegisterSingleton<INetworkService, NetworkService>();
            container.RegisterSingleton<IQRCodeService, QRCodeService>();
            container.RegisterSingleton<ISignalRService, SignalRService>();
            container.RegisterSingleton<IConfigurationService, ConfigurationService>();
            container.RegisterSingleton<IProcessStartService, ProcessStartService>();
            container.RegisterSingleton<IProcessEnvironmentService, ProcessEnvironmentService>();
            container.RegisterSingleton<IApplicationEnvironmentService, ApplicationEnvironmentService>();
            container.RegisterSingleton<IWindowModeService, WindowModeService>();
        }
    }
}

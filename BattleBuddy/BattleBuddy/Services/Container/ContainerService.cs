using BattleBuddy.Services.Messaging;
using BattleBuddy.Services.SignalR;
using BattleBuddy.ViewModel;
using BattleBuddy.ViewModels;

namespace BattleBuddy.Services.Container
{
    public static class ContainerService
    {
        public static void SetupContainer(SimpleInjector.Container container)
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
            container.RegisterSingleton<IOverlayManager, OverlayManager>();
            container.RegisterSingleton<IWindowLayoutService, WindowLayoutService>();
            container.RegisterSingleton<ResourceProvider>();
            container.RegisterSingleton<JsInteractionService>();
            container.RegisterSingleton<DtoFactory>();
        }
    }
}

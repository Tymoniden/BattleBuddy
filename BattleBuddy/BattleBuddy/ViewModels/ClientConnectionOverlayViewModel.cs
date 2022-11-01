using BattleBuddy.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleBuddy.ViewModels
{
    public class ClientConnectionOverlayViewModel : Base.ViewModel
    {
        private readonly IClientEndpointService _clientEndpointService;

        public ClientConnectionOverlayViewModel(IHotKeyRegistrationService hotKeyRegistrationService, IClientEndpointService clientEndpointService)
        {
            if (hotKeyRegistrationService is null)
            {
                throw new ArgumentNullException(nameof(hotKeyRegistrationService));
            }

            _clientEndpointService = clientEndpointService ?? throw new ArgumentNullException(nameof(clientEndpointService));
            _clientEndpointService.SetPort(500);
            hotKeyRegistrationService.RegisterHotKey(Key.F5, ModifierKeys.None, "Display connection options", () => IsVisible = !IsVisible);
        }

        public ObservableCollection<string> Endpoints { get; } = new();

        public string SelectedEndpoint
        {
            get => GetValue<string>() ?? string.Empty;
            set => SetValue(value);
        }

        public bool IsVisible
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        public async Task Setup()
        {
            var endpoints = await _clientEndpointService.GetEndpointOptions();

            Endpoints.Clear();
            foreach(var endpoint in endpoints)
            {
                Endpoints.Add(endpoint);
            }
        }
    }
}

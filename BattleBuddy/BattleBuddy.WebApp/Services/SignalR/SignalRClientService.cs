using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class SignalRClientService
    {
        private readonly NavigationManager _navigationManager;
        private HubConnection? _hubConnection;

        public SignalRClientService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        }

        public async Task Initialize()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/GameHub"))
                .Build();

            await _hubConnection.StartAsync();
        }

        public async Task Dispose()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();
            }
        }
        
        public async Task SendMessage(string methodName, CancellationToken cancellationToken, params object[] parameters)
        {
            if (_hubConnection == null)
            {
                return;
            }

            switch (parameters.Length)
            {
                case 0:
                    await _hubConnection.SendAsync(methodName, cancellationToken);
                    break;
                case 1:
                    await _hubConnection.SendAsync(methodName, parameters[0], cancellationToken);
                    break;
                case 2:
                    await _hubConnection.SendAsync(methodName, parameters[0], parameters[1], cancellationToken);
                    break;
                case 3:
                    await _hubConnection.SendAsync(methodName, parameters[0], parameters[1], parameters[2], cancellationToken);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameters));
            }

        }
        
        public void SubscribeToMessage(string messageName, Action callback)
        {
            if (_hubConnection != null)
            {
                _hubConnection.On(messageName, callback);
            }
        }

        public void SubscribeToMessage<T1,T2>(string messageName, Action<T1, T2> callback)
        {
            if (_hubConnection != null)
            {
                _hubConnection.On(messageName, callback);
            }
        }
    }
}

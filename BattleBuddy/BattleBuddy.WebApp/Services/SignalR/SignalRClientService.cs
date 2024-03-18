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

        public async Task SendMessage(string methodName, CancellationToken cancellationToken)
        {
            if (_hubConnection != null)
            {
                await _hubConnection.SendAsync(methodName, cancellationToken);
            }
        }

        public async Task SendMessage(string methodName, object argument, CancellationToken cancellationToken)
        {
            if (_hubConnection != null)
            {
                await _hubConnection.SendAsync(methodName, argument, cancellationToken);
            }
        }

        public async Task SendMessage(string methodName, object argument1, object argument2, CancellationToken cancellationToken)
        {
            if (_hubConnection != null)
            {
                await _hubConnection.SendAsync(methodName, argument1, argument2, cancellationToken);
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

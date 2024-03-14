using BattleBuddy.BlazorWebApp.Client.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public sealed class SignalRService : ISignalRService
    {
        SignalRConfiguration? _configuration;
        HubConnection? _hubConnection;

        // TODO think about ctor configuration to avoid null reference of config and connection

        public async Task StartUp(SignalRConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(configuration.ToUrl())
                .WithAutomaticReconnect()
                .Build();

            await Connect();
        }

        public async Task Send(string messageType)
        {
            await Connect();

            await _hubConnection?.SendAsync(messageType);
        }

        public async Task Send<T>(string messageType, T param)
        {
            await Connect();

            await _hubConnection?.SendAsync(messageType, param);
        }

        async Task Connect()
        {
            if (_hubConnection?.State == HubConnectionState.Disconnected)
            {
                await _hubConnection.StartAsync();

                //try
                //{
                //    await _hubConnection.StartAsync();
                //}
                //catch(Exception ex)
                //{
                //    // Logging?
                //}
            }
        }
    }
}

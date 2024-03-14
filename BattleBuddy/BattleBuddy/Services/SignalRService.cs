using BattleBuddy.BlazorWebApp.Client.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public class SignalRService : ISignalRService
    {
        SignalRConfiguration? _configuration;
        HubConnection _hubConnection;

        public async Task StartUp(SignalRConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(configuration.ToUrl())
                .WithAutomaticReconnect()
                .Build();

            await Connect();
        }

        public async Task Connect()
        {
            if (_hubConnection?.State == HubConnectionState.Disconnected)
            {
                await _hubConnection.StartAsync();
            }

            // TODO necessary?
            //_hubConnection.Closed += async (error) =>
            //{
            //    await Task.Delay(new Random().Next(0, 5) * 1000);
            //    await _hubConnection.StartAsync();
            //};
        }

        public void RegisterCallback(string method, Func<Task> callback)
        {
            if (IsConnected())
            {
                return;
            }

            _hubConnection?.On(method, callback);
        }

        public void RegisterCallback<T1>(string method, Action<T1> callback)
        {
            if (IsConnected())
            {
                return;
            }

            _hubConnection?.On(method, callback);
        }

        public void RegisterCallback<T1>(string method, Func<T1, Task> callback)
        {
            if (IsConnected())
            {
                return;
            }

            _hubConnection?.On(method, callback);
        }

        public void RegisterCallback<T1, T2>(string method, Func<T1, T2, Task> callback)
        {
            if (IsConnected())
            {
                return;
            }

            _hubConnection?.On(method, callback);
        }

        public void RegisterCallback<T1, T2>(string method, Action<T1, T2> callback)
        {
            if (IsConnected())
            {
                return;
            }

            _hubConnection?.On(method, callback);
        }

        bool IsConnected()
        {
            if (_hubConnection?.State == HubConnectionState.Connected || _hubConnection?.State == HubConnectionState.Connecting)
            {
                return true;
            }

            return false;
        }
    }
}

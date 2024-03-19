using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BattleBuddy.Services.SignalR
{
    public class SignalRService : ISignalRService
    {
        HubConnection? _connection;

        public async Task Connect(int port, string hub)
        {
            if (IsConnected())
            {
                return;
            }

            _connection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:{port}/{hub}")
                .WithAutomaticReconnect()
                .Build();

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };

            await _connection.StartAsync();
        }

        public void RegisterCallback(string method, Action callback)
        {
            _connection?.On(method, callback);
        }

        public void RegisterCallback(string method, Func<Task> callback)
        {
            _connection?.On(method, callback);
        }

        public void RegisterCallback<T1>(string method, Action<T1> callback)
        {
            _connection?.On(method, callback);
        }

        public void RegisterCallback<T1>(string method, Func<T1, Task> callback)
        {
            _connection?.On(method, callback);
        }

        public void RegisterCallback<T1, T2>(string method, Func<T1, T2, Task> callback)
        {
            _connection?.On(method, callback);
        }

        public void RegisterCallback<T1, T2>(string method, Action<T1, T2> callback)
        {
            _connection?.On(method, callback);
        }

        bool IsConnected()
        {
            if (_connection?.State == HubConnectionState.Connected || _connection?.State == HubConnectionState.Connecting)
            {
                return true;
            }

            return false;
        }
    }
}

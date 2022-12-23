using Microsoft.AspNetCore.SignalR.Client;

namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public class ListViewInteractionFacade : IListViewInteractionFacade
    {
        private HubConnection? _hubConnection;

        public async Task ExpandLeft()
        {
            await EnsureConnection();
            if (_hubConnection != null)
            {
                await _hubConnection.SendAsync("RequestFocus", "left");
            }
        }

        public async Task ExpandRight()
        {
            await EnsureConnection();
            if (_hubConnection != null)
            {
                await _hubConnection.SendAsync("RequestFocus", "left");
            }
        }

        public async Task JustifyBoth()
        {
            await EnsureConnection();
            if (_hubConnection != null)
            {
                await _hubConnection.SendAsync("RequestFocus", null);
            }
        }

        public async Task ReloadLists()
        {
            await EnsureConnection();
            if (_hubConnection != null)
            {
                await _hubConnection.SendAsync("RequestReload");
            }
        }

        public async Task ScrollToEntry(ListViewIdentifier listViewIdentifier, int index)
        {
            await EnsureConnection();
            //await _hubConnection.SendAsync("RequestReload");
        }

        public async Task ScrollToPercentage(ListViewIdentifier listViewIdentifier, int percentage)
        {
            await EnsureConnection();
            //await _hubConnection.SendAsync("RequestReload");
        }
        
        private async Task EnsureConnection()
        {
            if (!IsConnected() && _hubConnection != null)
            {
                await _hubConnection.StartAsync();
            }
        }

        private bool IsConnected() => _hubConnection?.State == HubConnectionState.Connected;
    }
}

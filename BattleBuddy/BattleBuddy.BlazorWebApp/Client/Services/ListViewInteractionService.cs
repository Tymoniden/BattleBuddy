using Microsoft.AspNetCore.SignalR.Client;

namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public class ListViewInteractionFacade
    {
        private HubConnection? _hubConnection;

        public async Task ExpandLeft()
        {
            if (!IsConnected())
            {
                return;
            }

            await _hubConnection.SendAsync("RequestFocus", "left");
        }

        public async Task TaskExpandRight()
        {
            if (!IsConnected())
            {
                return;
            }

            await _hubConnection.SendAsync("RequestFocus", "left");
        }

        public async Task JustifyBoth()
        {
            if (!IsConnected())
            {
                return;
            }

            await _hubConnection.SendAsync("RequestFocus", null);
        }

        private bool IsConnected() => _hubConnection?.State == HubConnectionState.Connected;
    }
}

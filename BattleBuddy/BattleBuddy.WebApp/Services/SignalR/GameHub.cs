using Microsoft.AspNetCore.SignalR;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class GameHub : Hub
    {
        public async Task SendMessage(string playerA, string playerB)
        {
            await Clients.All.SendAsync("UpdateScore", playerA, playerB);
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task Initialize()
        {
            await Clients.All.SendAsync("Initialized");
        }
    }
}

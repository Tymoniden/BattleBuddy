using Microsoft.AspNetCore.SignalR;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class BbHub : Hub
    {
        public async Task SendMessage(string playerA, string playerB)
        {
            await Clients.All.SendAsync("UpdateScore", playerA, playerB);
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

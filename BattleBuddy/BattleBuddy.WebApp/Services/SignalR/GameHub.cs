using BattleBuddy.WebApp.StateContainers;
using Microsoft.AspNetCore.SignalR;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class GameHub : Hub
    {
        private readonly Game _game;

        public GameHub(Game game)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public async Task SendMessage(string playerA, string playerB)
        {
            await Clients.All.SendAsync("UpdateScore", playerA, playerB);
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task InitializeMessage()
        {
            await Clients.All.SendAsync("Initialized");
        }

        public async Task RequestListUpdateMessage()
        {
            await Clients.Others.SendAsync(nameof(RequestListUpdateMessage));
        }

        public async Task UpdateArmyListEntries(List<ArmyListEntryDto> armyListEntries)
        {
            _game.ArmyListEntries.Clear();
            _game.ArmyListEntries.AddRange(armyListEntries);

            await Clients.All.SendAsync("ReloadArmyLists");
        }
    }
}

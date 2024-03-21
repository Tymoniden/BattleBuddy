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

        public async Task ScrollToArmyListEntryMessage(Guid uid)
        {
            var ctx = Context;
            var clients = Clients;

            await Clients.Others.SendAsync("ScrollDisplayToArmyList", uid);
        }

        public async Task ScrollToPercentMessage(string origin, int percentage)
        {
            await Clients.Others.SendAsync("ScrollToPercent", origin, percentage);
        }

        public async Task RequestToggleQrCodeMessage()
        {
            await Clients.Others.SendAsync("ToggleQrCode");
        }

        public async Task ExtendLeftColumn()
        {
            _game.ColumnLayout = ColumnLayout.ExtendLeft;
        }

        public async Task ExtendRightColumn()
        {
            _game.ColumnLayout = ColumnLayout.ExtendRight;
        }

        public async Task JustifyColumns()
        {
            _game.ColumnLayout = ColumnLayout.Justify;
        }

        public async Task RequestExtendLeftColumnMessage()
        {
            await Clients.All.SendAsync("ExtendLeftColumn");
            _game.ColumnLayout = ColumnLayout.ExtendLeft;
        }

        public async Task RequestExtendRightColumnMessage()
        {
            await Clients.All.SendAsync("ExtendRightColumn");
            _game.ColumnLayout = ColumnLayout.ExtendRight;
        }

        public async Task RequestJustifyColumnsMessage()
        {
            await Clients.All.SendAsync("JustifyColumns");
            _game.ColumnLayout = ColumnLayout.Justify;
        }
    }
}

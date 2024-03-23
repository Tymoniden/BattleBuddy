using BattleBuddy.Shared;
using BattleBuddy.WebApp.StateContainers;
using Microsoft.AspNetCore.SignalR;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class GameHub : Hub, IGameHub
    {
        private readonly Game _game;

        public GameHub(Game game)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public async Task InitializeMessage() => await Clients.All.SendAsync(nameof(GameHubSignals.Initialized));

        public async Task RequestListUpdateMessage() => await Clients.Others.SendAsync(nameof(RequestListUpdateMessage));

        public async Task UpdateArmyListEntries(List<ArmyListEntryDto> armyListEntries)
        {
            _game.ArmyListEntries.Clear();
            _game.ArmyListEntries.AddRange(armyListEntries);

            await Clients.All.SendAsync(nameof(GameHubSignals.ReloadArmyLists));
        }

        public async Task ScrollToArmyListEntryMessage(Guid uid)
        {
            var ctx = Context;
            var clients = Clients;

            await Clients.Others.SendAsync(nameof(GameHubSignals.ScrollDisplayToArmyList), uid);
        }

        public async Task ScrollToPercentMessage(string origin, int percentage) => await Clients.Others.SendAsync(nameof(GameHubSignals.ScrollToPercent), origin, percentage);

        public async Task RequestToggleQrCodeMessage() => await Clients.Others.SendAsync(nameof(GameHubSignals.ToggleQrCode));

        public async Task ExtendLeftColumn()
        {
            _game.ColumnLayout = ColumnLayout.ExtendLeft;
            await Task.CompletedTask;
        }

        public async Task ExtendRightColumn()
        {
            _game.ColumnLayout = ColumnLayout.ExtendRight;
            await Task.CompletedTask;
        }

        public async Task JustifyColumns()
        {
            _game.ColumnLayout = ColumnLayout.Justify;
            await Task.CompletedTask;
        }

        public async Task RequestExtendLeftColumnMessage()
        {
            await Clients.All.SendAsync(nameof(GameHubSignals.ExtendLeftColumn));
            _game.ColumnLayout = ColumnLayout.ExtendLeft;
        }

        public async Task RequestExtendRightColumnMessage()
        {
            await Clients.All.SendAsync(nameof(GameHubSignals.ExtendRightColumn));
            _game.ColumnLayout = ColumnLayout.ExtendRight;
        }

        public async Task RequestJustifyColumnsMessage()
        {
            await Clients.All.SendAsync(nameof(GameHubSignals.JustifyColumns));
            _game.ColumnLayout = ColumnLayout.Justify;
        }

        public async Task RequestChangeZoomFactorMessage(SideIdentifier sideIdentifier, int zoomFactor)
        {
            await Clients.All.SendAsync(nameof(RequestChangeZoomFactorMessage), sideIdentifier, zoomFactor);
            _game.ChangeZoomFactor(sideIdentifier, zoomFactor);
        }
    }
}

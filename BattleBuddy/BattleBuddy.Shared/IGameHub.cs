using BattleBuddy.Shared;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public interface IGameHub
    {
        public Task InitializeMessage();

        public Task RequestListUpdateMessage();

        public Task UpdateArmyListEntries(List<ArmyListEntryDto> armyListEntries);

        public Task ScrollToArmyListEntryMessage(Guid uid);

        public Task ScrollToPercentMessage(string origin, int percentage);

        public Task RequestToggleQrCodeMessage();

        public Task ExtendLeftColumn();

        public Task ExtendRightColumn();

        public Task JustifyColumns();

        public Task RequestExtendLeftColumnMessage();

        public Task RequestExtendRightColumnMessage();

        public Task RequestJustifyColumnsMessage();

        public Task RequestChangeZoomFactorMessage(SideIdentifier sideIdentifier, int zoomFactor);
    }
}

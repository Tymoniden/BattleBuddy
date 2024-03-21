using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class SignalRMessageFactory
    {
        public ScrollToArmyListEntryMessage CreateScrollToArmyListEntryMessage(Guid id)
        {
            return new ScrollToArmyListEntryMessage { Uid = id };
        }

        public ScrollToPercentMessage CreateScrollToPercent(string origin, int percent)
        {
            return new ScrollToPercentMessage { Origin = origin, Percent = percent };
        }

        public InitializeMessage CreateInitializeMessage()
        {
            return new InitializeMessage();
        }

        public RequestListUpdateMessage CreateRequestListUpdateMessage()
        {
            return new RequestListUpdateMessage();
        }

        public RequestToggleQrCodeMessage CreateRequestToggleQrCodeMessage()
        {
            return new RequestToggleQrCodeMessage();
        }

        public RequestExtendLeftColumnMessage CreateRequestExtendLeftColumnMessage()
        {
            return new RequestExtendLeftColumnMessage();
        }

        public RequestExtendRightColumnMessage CreateRequestExtendRightColumnMessage()
        {
            return new RequestExtendRightColumnMessage();
        }

        public RequestJustifyColumnsMessage CreateRequestJustifyColumnsMessage()
        {
            return new RequestJustifyColumnsMessage();
        }
    }
}

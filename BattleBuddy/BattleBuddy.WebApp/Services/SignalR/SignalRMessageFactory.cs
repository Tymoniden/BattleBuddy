using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class SignalRMessageFactory
    {
        public ScrollToArmyListEntryMessage CreateScrollToArmyListEntryMessage(Guid id)
        {
            return new ScrollToArmyListEntryMessage();
        }

        public InitializeMessage CreateInitializeMessage()
        {
            return new InitializeMessage();
        }
    }
}

using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class InitializeMessage : ISignalRMessage
    {
        public string Name => nameof(GameHub.InitializeMessage);
    }
}

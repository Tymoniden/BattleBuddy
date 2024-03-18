namespace BattleBuddy.WebApp.Services.SignalR.Messages
{
    public class ScrollToArmyListEntryMessage : ISignalRMessage
    {
        public string Name { get; set; } = "ScrollToArmyListEntryMessage";
    }
}

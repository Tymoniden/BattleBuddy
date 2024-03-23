using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR;

public class ScrollToPercentMessage : ISignalRMessage
{
    public string Name => nameof(ScrollToPercentMessage);
    public object[] Params => new object[] { Origin, Percent };
    public string Origin { get; set; } = string.Empty;
    public int Percent { get; set; }
}
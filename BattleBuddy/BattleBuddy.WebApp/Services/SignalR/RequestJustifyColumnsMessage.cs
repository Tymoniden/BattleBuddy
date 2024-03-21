using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR;

public class RequestJustifyColumnsMessage : ISignalRMessage
{
    public string Name => nameof(RequestJustifyColumnsMessage);
    public object[] Params => Array.Empty<object>();
}
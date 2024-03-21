using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR;

public class RequestExtendLeftColumnMessage: ISignalRMessage
{
    public string Name => nameof(RequestExtendLeftColumnMessage);
    public object[] Params => Array.Empty<object>();
}
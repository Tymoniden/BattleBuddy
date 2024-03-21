using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR;

public class RequestExtendRightColumnMessage: ISignalRMessage
{
    public string Name => nameof(RequestExtendRightColumnMessage);
    public object[] Params => Array.Empty<object>();
}
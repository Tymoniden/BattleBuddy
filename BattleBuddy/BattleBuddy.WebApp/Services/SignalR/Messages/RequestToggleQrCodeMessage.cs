namespace BattleBuddy.WebApp.Services.SignalR.Messages
{
    public class RequestToggleQrCodeMessage : ISignalRMessage
    {
        public string Name => nameof(GameHub.RequestToggleQrCodeMessage);
        public object[] Params => Array.Empty<object>();
    }
}

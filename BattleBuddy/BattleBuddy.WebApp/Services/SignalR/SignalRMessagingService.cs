using BattleBuddy.WebApp.Services.SignalR.Messages;

namespace BattleBuddy.WebApp.Services.SignalR
{
    public class SignalRMessagingService
    {
        private readonly SignalRClientService _signalRClientService;

        public SignalRMessagingService(SignalRClientService signalRClientService)
        {
            _signalRClientService = signalRClientService ?? throw new ArgumentNullException(nameof(signalRClientService));
        }

        public Task Initialize() => _signalRClientService.Initialize();

        public Task Dispose() => _signalRClientService.Dispose();

        public Task SendMessage()
        {
            return _signalRClientService.SendMessage("SendMessage", "1", "2", CancellationToken.None);
        }

        public Task SendMessage(ISignalRMessage message)
        {
            return _signalRClientService.SendMessage(message.Name, CancellationToken.None);
        }

        public void SubscribeToMessage(string messageName, Action callback)
        {
            _signalRClientService.SubscribeToMessage(messageName, callback);
        }

        public void SubscribeToMessage<T1,T2>(string messageName, Action<T1, T2> callback)
        {
            _signalRClientService.SubscribeToMessage(messageName, callback);
        }
    }
}

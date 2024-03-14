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

        public void RegisterToMessage<T1,T2>(string messageName, Action<T1, T2> callback)
        {
            _signalRClientService.SubscribeToMessage(messageName, callback);
        }
    }
}

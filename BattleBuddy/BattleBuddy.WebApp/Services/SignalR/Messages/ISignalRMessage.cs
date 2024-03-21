namespace BattleBuddy.WebApp.Services.SignalR.Messages
{
    public interface ISignalRMessage
    {
        public string Name { get; }

        public object[] Params { get; }
    }
}
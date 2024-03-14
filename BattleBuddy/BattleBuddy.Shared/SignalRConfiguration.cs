namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public sealed class SignalRConfiguration
    {
        public string Protocol { get; set; } = "http";
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string HubName { get; set; } = string.Empty;
    }
}

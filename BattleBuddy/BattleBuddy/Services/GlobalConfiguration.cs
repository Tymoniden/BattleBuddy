namespace BattleBuddy.Services
{
    public sealed class GlobalConfiguration
    {
        public int WebAppPort { get; } = 5010;

        public string WebAppPath { get; } = "BattleBuddy.BlazorWebApp\\Server\\bin\\Release\\net6.0\\publish\\BattleBuddy.BlazorWebApp.Server.exe";

        public int CommunicationAppPort { get; } = 5009;

        public string CommunicationAppPath { get; } = "BattleBuddy.SignalRServer\\bin\\Release\\net6.0\\BattleBuddy.SignalRServer.exe";
    }
}

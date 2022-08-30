namespace BattleBuddy.SignalRServer.Services
{
    public interface ICommandLineArgumentService
    {
        public int? GetPort(string[] arguments);
    }
}

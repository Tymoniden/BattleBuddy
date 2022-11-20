namespace BattleBuddy.BlazorWebApp.Server.Services
{
    public interface ISignalRService
    {
        void Connect(int port);
    }
}
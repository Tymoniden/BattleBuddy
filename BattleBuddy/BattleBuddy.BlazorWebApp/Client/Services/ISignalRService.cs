namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public interface ISignalRService
    {
        Task Send<T>(string messageType, T param);
        Task Send(string messageType);
        Task StartUp(SignalRConfiguration configuration);
    }
}
namespace BattleBuddy.Services
{
    public interface IProcessStartService
    {
        void StartCommunicationApp(int port);
        void StartWebApp(int port);
        void StopCommunicationApp();
        void StopWebApp();
    }
}

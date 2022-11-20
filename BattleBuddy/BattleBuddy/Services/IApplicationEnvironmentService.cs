namespace BattleBuddy.Services
{
    public interface IApplicationEnvironmentService
    {
        void SetupEnvironment();
        void ShutdownEnvironment();
    }
}
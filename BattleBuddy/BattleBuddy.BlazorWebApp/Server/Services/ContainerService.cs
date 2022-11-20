namespace BattleBuddy.BlazorWebApp.Server.Services
{
    public static class ContainerService
    {
        public static void AddBattleBuddyServices(this IServiceCollection services)
        {
            services.AddSingleton<ISignalRService, SignalRService>();
        }
    }
}

using BattleBuddy.WebApp.Services.SignalR;

namespace BattleBuddy.WebApp
{
    public static class InitializeApplicationExtension
    {
        public static void InitializeApplication(this WebApplication app)
        {
            //app.Services.GetService<SignalRMessagingService>()?.SubscribeToMessage(nameof(GameHub.));
        }
    }
}

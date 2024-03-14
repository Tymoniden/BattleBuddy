namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public static class SignalRConfigurationExtension
    {
        public static string ToUrl(this SignalRConfiguration configuration)
        {
            return $"{configuration.Protocol}://{configuration.Host}:{configuration.Port}/{configuration.HubName}";
        }
    }
}

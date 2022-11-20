namespace BattleBuddy.Services
{
    public class ConfigurationService : IConfigurationService
    {
        GlobalConfiguration _global = new GlobalConfiguration();

        public GlobalConfiguration GetGlobalConfiguration() => _global;
    }
}

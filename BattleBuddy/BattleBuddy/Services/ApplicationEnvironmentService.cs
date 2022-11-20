using System.Diagnostics;

namespace BattleBuddy.Services
{
    public sealed class ApplicationEnvironmentService : IApplicationEnvironmentService
    {
        private readonly IConfigurationService _configurationService;
        private readonly IProcessStartService _processStartService;

        public ApplicationEnvironmentService(IConfigurationService configurationService, IProcessStartService processStartService)
        {
            _configurationService = configurationService ?? throw new System.ArgumentNullException(nameof(configurationService));
            _processStartService = processStartService ?? throw new System.ArgumentNullException(nameof(processStartService));
        }

        public void SetupEnvironment()
        {
            if(Debugger.IsAttached)
            {
                return;
            }

            _processStartService.StartCommunicationApp(_configurationService.GetGlobalConfiguration().CommunicationAppPort);
            _processStartService.StartWebApp(_configurationService.GetGlobalConfiguration().WebAppPort);
        }

        public void ShutdownEnvironment()
        {
            _processStartService.StopCommunicationApp();
            _processStartService.StopWebApp();
        }
    }
}

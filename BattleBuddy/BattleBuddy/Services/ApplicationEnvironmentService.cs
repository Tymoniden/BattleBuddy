using System;
using System.Diagnostics;
using BattleBuddy.Services.SignalR;

namespace BattleBuddy.Services
{
    public sealed class ApplicationEnvironmentService : IApplicationEnvironmentService
    {
        private readonly IConfigurationService _configurationService;
        private readonly IProcessStartService _processStartService;
        private readonly ISignalRService _signalRService;

        public ApplicationEnvironmentService(IConfigurationService configurationService, IProcessStartService processStartService, ISignalRService signalRService)
        {
            _configurationService = configurationService ?? throw new System.ArgumentNullException(nameof(configurationService));
            _processStartService = processStartService ?? throw new System.ArgumentNullException(nameof(processStartService));
            _signalRService = signalRService ?? throw new System.ArgumentNullException(nameof(signalRService));
        }

        public void SetupEnvironment()
        {
            _signalRService.Connect(5432, "GameHub");

            if(Debugger.IsAttached)
            {
                return;
            }

            //_processStartService.StartCommunicationApp(_configurationService.GetGlobalConfiguration().CommunicationAppPort);
            //_processStartService.StartWebApp(_configurationService.GetGlobalConfiguration().WebAppPort);
        }

        public void ShutdownEnvironment()
        {
            //_processStartService.StopCommunicationApp();
            //_processStartService.StopWebApp();
        }
    }
}

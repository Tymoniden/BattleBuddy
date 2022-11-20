using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace BattleBuddy.Services
{
    public class ProcessStartService : IProcessStartService
    {
        readonly IConfigurationService _configurationService;
        Process? _communicationAppProcess;
        Process? _webAppProcess;

        public ProcessStartService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public void StartWebApp(int port)
        {
            if(port < 1024 || port > 65536)
            {
                throw new ArgumentOutOfRangeException(nameof(port));
            }

            var webAppPath = Path.Combine(GetExecutingPath(), _configurationService.GetGlobalConfiguration().WebAppPath);

            var processInfo = new ProcessStartInfo
            {
                UseShellExecute= true,
                FileName = webAppPath,
                Arguments = port.ToString()
            };

            _webAppProcess = Process.Start(processInfo);
        }

        public void StartCommunicationApp(int port)
        {
            if (port < 1024 || port > 65536)
            {
                throw new ArgumentOutOfRangeException(nameof(port));
            }

            var comAppPath = Path.Combine(GetExecutingPath(), _configurationService.GetGlobalConfiguration().WebAppPath);

            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = comAppPath,
                Arguments = port.ToString()
            };

            _communicationAppProcess = Process.Start(processInfo);
        }

        public void StopCommunicationApp()
        {
            _communicationAppProcess?.Kill();
        }

        public void StopWebApp()
        {
            _webAppProcess?.Kill();
        }

        string GetExecutingPath()
        {
            var executingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (executingPath == null)
            {
                throw new InvalidOperationException("Can't fetch executing path.");
            }

            if (Debugger.IsAttached)
            {
                executingPath = Path.Combine(executingPath, "..", "..", "..", "..");
            }

            return executingPath;
        }
    }
}

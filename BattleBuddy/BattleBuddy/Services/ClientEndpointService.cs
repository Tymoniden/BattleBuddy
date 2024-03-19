using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public class ClientEndpointService : IClientEndpointService
    {
        private readonly IConfigurationService _configurationService;
        private readonly INetworkService _networkService;

        public ClientEndpointService(IConfigurationService configurationService, INetworkService networkService)
        {
            _configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            _networkService = networkService ?? throw new ArgumentNullException(nameof(networkService));
        }

        public async Task<List<string>> GetEndpointOptions()
        {
            var endpoints = new List<string>();
            var port = _configurationService.GetGlobalConfiguration().WebAppPort;

            foreach (var endpoint in await _networkService.GetIpAddresses())
            {
                endpoints.Add($"http://{endpoint}:{port}");
            }

            return endpoints;
        }
    }
}

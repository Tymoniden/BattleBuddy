using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public class ClientEndpointService : IClientEndpointService
    {
        private readonly INetworkService _networkService;
        private int _port;

        public ClientEndpointService(INetworkService networkService)
        {
            _networkService = networkService ?? throw new System.ArgumentNullException(nameof(networkService));
        }

        public async Task<List<string>> GetEndpointOptions()
        {
            var endpoints = new List<string>();

            if (_port == 0)
            {
                return endpoints;
            }

            foreach (var endpoint in await _networkService.GetIpAdresses())
            {
                endpoints.Add($"http://{endpoint}:{_port}");
            }

            return endpoints;
        }

        public void SetPort(int port)
        {
            if (port <= 0 || port > 65536)
            {
                throw new ArgumentOutOfRangeException($"Port number has to be between 0 and 65536");
            }

            _port = port;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public interface IClientEndpointService
    {
        Task<List<string>> GetEndpointOptions();
        void SetPort(int port);
    }
}
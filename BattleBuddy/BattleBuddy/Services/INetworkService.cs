using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public interface INetworkService
    {
        Task<List<string>> GetIpAddresses();
    }
}
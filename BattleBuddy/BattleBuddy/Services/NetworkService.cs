using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public class NetworkService : INetworkService
    {
        public async Task<List<string>> GetIpAddresses()
        {
            var hostName = Dns.GetHostName();
            var entry = await Dns.GetHostEntryAsync(hostName);

            var ipAddresses = new List<string>();

            foreach (var address in entry.AddressList.Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
            {
                ipAddresses.Add(address.ToString());
            }

            return ipAddresses;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public class NetworkService
    {
        public async Task<List<string>> GetIpAdresses()
        {
            var hostName = Dns.GetHostName();
	        var entry = await Dns.GetHostEntryAsync(hostName);
	        
            var ipAdresses = new List<string>();

	        foreach(var address in entry.AddressList.Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)){
		        ipAdresses.Add(address.ToString());
	        }

            return ipAdresses;
        }
    }
}

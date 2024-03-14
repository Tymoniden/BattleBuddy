using BattleBuddy.BlazorWebApp.Client.Services;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public static class SignalRExtensions
    {
        public static void Setup(this ISignalRService signalRService) 
        {
            Task.Run(async () =>
            {
                // TODO retrieve from console arguments
                var configuration = new SignalRConfiguration
                {
                    Host = "localhost",
                    HubName = "battleBuddyHub",
                    Port = 5010
                };
                await signalRService.StartUp(configuration);
            }) ;
        }
    }
}

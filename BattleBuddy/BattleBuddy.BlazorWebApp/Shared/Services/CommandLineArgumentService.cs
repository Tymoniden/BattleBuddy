namespace BattleBuddy.BlazorWebApp.Shared.Services
{
    public class CommandLineArgumentService : ICommandLineArgumentService
    {
        public int? GetPort(string[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                return null;
            }

            if (int.TryParse(arguments[0], out var port))
            {
                return port;
            }

            return null;
        }
    }
}

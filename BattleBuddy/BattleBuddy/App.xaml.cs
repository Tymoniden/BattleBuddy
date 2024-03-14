using BattleBuddy.Services;
using SimpleInjector;
using System.Windows;


namespace BattleBuddy
{
    public partial class App : Application
    {
        public App()
        {
            var container = new Container();
            ContainerService.SetupContainer(container);
            ServiceLocatorService.RegisterContainer(container);
            ServiceLocatorService.GetInstance<ISignalRService>().Setup();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ServiceLocatorService.GetInstance<IApplicationEnvironmentService>().ShutdownEnvironment();
        }
    }
}

using BattleBuddy.Services;
using BattleBuddy.Services.Container;
using SimpleInjector;
using System.Windows;

namespace BattleBuddy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var container = new Container();
            ContainerService.SetupContainer(container);
            ServiceLocatorService.RegisterContainer(container);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ServiceLocatorService.GetInstance<IApplicationEnvironmentService>().ShutdownEnvironment();
        }
    }
}
